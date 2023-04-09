using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Game Stuff")]
    [Tooltip("This reference the hook, where the New Block should instantiate on")]
    public Transform hook;
    [Tooltip("This reference the New Block Prefab")]
    public GameObject TowerBlock;
    [Tooltip("Where should all the Tower Block go to after they drop.")]
    public Transform gameContent;
    [Tooltip("The out of Bounds Transform when the block touch this.")]
    public Transform outOfBounds;
    [Tooltip("The movement speed of the Hook.")]
    public float hookSpeed = 1f;
    [Tooltip("The overall move up everytime the player successfully placed a block.")]
    public float moveAmount = 1;
    [Tooltip("The camera moving speed.")]
    public float moveSpeed = 1f;

    public Rigidbody2D towerRigidbody;
    public float wobbleForce = 0.1f;
    public float wobbleTorque = 0.1f;
    public int wobbleIncrement = 1; 


    [Header("UI Stuff")]
    [Tooltip("The User Interface for Hearts.")]
    public GameObject[] hearts;
    [Tooltip("The User Interface for Stacked Blocked")]
    public TextMeshProUGUI stacked;
    [Tooltip("The Panel for the game ends.")]
    public GameObject endingPanel;
    [Tooltip("The text on the Ending Panel.")]
    public TextMeshProUGUI endingText;
    [Tooltip("The Panel for player prompt exits.")]
    public GameObject leavePanel;
    [Tooltip("The Page scripts.")]
    public SkyscraperGamePage skyScraperPage;
    [Space(5)]
    [Header("Buttons")]
    public Button yesButton;
    public Button noButton;
    public Button okButton;
    public Button backButton;


    private bool moveRight = false;
    private bool moveUp = false;
    private GameObject currentBlock;
    private int blockCount = 0;
    private int lifeUsed = 0;
    private Camera mainCamera;
    private Vector3 newHookPosition;

    private Vector3 initialOutOfBoundsPosition;
    private Vector3 initialHookPosition;
    private Vector3 initialCameraPosition;

    private Vector3 finalOutOfBoundsPosition;
    private Vector3 finalHookPosition;
    private Vector3 finalCameraPosition;

    private void OnEnable()
    {
        mainCamera = Camera.main;

        initialOutOfBoundsPosition = outOfBounds.position;
        initialHookPosition = hook.position;
        initialCameraPosition = mainCamera.transform.position;

        RegisterButton();
    }

    private void OnDisable()
    {

        ResetGame();
        UnRegisterButton();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnExit();
        }

        GameLoop();
    }

    private void ResetGame()
    {
        blockCount = 0;
        lifeUsed = 0;
        endingPanel.SetActive(false);

        foreach (GameObject heart in hearts)
        {
            heart.SetActive(true);
        }

        foreach (Transform tower in gameContent)
        {
            Destroy(tower.gameObject);
        }

        stacked.text = blockCount.ToString();

        outOfBounds.position = initialOutOfBoundsPosition;
        hook.position = initialHookPosition;
        mainCamera.transform.position = initialCameraPosition;
        moveUp = false;

        Time.timeScale = 1f;
    }
    private void RegisterButton()
    {
        yesButton.onClick.AddListener(OnClickYes);
        noButton.onClick.AddListener(OnClickNo);
        okButton.onClick.AddListener(OnClickOk);
        backButton.onClick.AddListener(OnExit);
    }

    private void UnRegisterButton()
    {
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();
        okButton.onClick.RemoveAllListeners();
        backButton.onClick.RemoveAllListeners();
    }

    private void InputCheck()
    {
        // Check if the player has tapped the screen
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (currentBlock != null)
                {
                    // Last block that spawned add Gravity
                    currentBlock.GetComponent<Rigidbody2D>().gravityScale = 1f;
                    currentBlock.transform.parent = gameContent;
                }
            }
        }
    }

    private void TowerGameStart()
    {
        if (currentBlock == null)
        {
            if (!moveUp)
                currentBlock = Instantiate(TowerBlock, hook.position, Quaternion.identity, hook);

        }
        else if (currentBlock.transform.parent != hook)
        {
            TowerBlockConditionCheck blockCondition = currentBlock.GetComponent<TowerBlockConditionCheck>();

            if (blockCount != 0 && blockCondition.collided == true || blockCondition.gameObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Water")))
            {
                currentBlock = null;

                if (!blockCondition.gameObject.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Tower")))
                {
                    MissedPlace();
                    Destroy(blockCondition.gameObject);
                }
                else
                {
                    if (blockCondition.distance < -0.5 || blockCondition.distance > 0.5)
                    {
                        MissedPlace();
                        Destroy(blockCondition.gameObject);
                    }
                    else
                    {
                        CorrectlyPlaced();
                    }
                }
            }
            else if (blockCondition.collided == true)
            {
                currentBlock = null;

                CorrectlyPlaced();
            }
        }
    }

    private void MissedPlace()
    {
        lifeUsed++;

        if (lifeUsed == 3)
        {
            EndingPrompt();
        }

        for (int i = 0; i < lifeUsed; i++)
        {
            hearts[i].SetActive(false);
        }

    }

    private void EndingPrompt()
    {
        Time.timeScale = 0f;

        if (blockCount >= 10)
        {
            endingText.text = "Game Ended!\nTower Height:" + blockCount.ToString() + "\n\nYour hardwork of building a skyscrapers have made the Mayor to give you another reward!\n\nDiscount Code:\nH+SKYSCRAPER1";
            endingPanel.SetActive(true);
        }
        else
        {
            endingText.text = "Game Ended!\nTower Height: " + blockCount.ToString() + "\n\nContinue playing to see what kind of rewards awaits!";
            endingPanel.SetActive(true);
        }
    }

    private void CorrectlyPlaced()
    {
        blockCount += 1;
        stacked.text = blockCount.ToString();
        currentBlock = null;

        finalOutOfBoundsPosition = outOfBounds.position + new Vector3(0, moveAmount, 0);
        finalHookPosition = hook.transform.position + new Vector3(0, moveAmount, 0);
        finalCameraPosition = mainCamera.transform.position + new Vector3(0, moveAmount, 0);
        moveUp = true;
    }

    private void MoveHook()
    {
        if (!moveUp)
        {
            newHookPosition = new Vector3(hook.position.x, hook.position.y, hook.position.z);
            if (moveRight)
            {
                newHookPosition.x += hookSpeed * Time.deltaTime;
            }
            else
            {
                newHookPosition.x -= hookSpeed * Time.deltaTime;
            }
            newHookPosition.x = Mathf.Clamp(newHookPosition.x, -2.0f, 2.0f);
            hook.position = newHookPosition;

            if (newHookPosition.x >= 2.0f)
                moveRight = false;
            if (newHookPosition.x <= -2.0f)
                moveRight = true;
        }

    }


    private void GameLoop()
    {
        InputCheck();
        TowerGameStart();
        MoveHook();
        MoveObjects();
        TowerWobbleEffect();

    }

    private void OnClickOk()
    {
        skyScraperPage.skyScraperGame.SetActive(false);
        skyScraperPage.skyScraperGameStart.SetActive(true);
    }

    private void OnExit()
    {
        Time.timeScale = 0f;
        leavePanel.SetActive(true);
    }

    private void OnClickYes()
    {
        leavePanel.SetActive(false);
        EndingPrompt();
    }

    private void OnClickNo()
    {
        Time.timeScale = 1f;
        leavePanel.SetActive(false);
    }

    private void MoveObjects()
    {
        if (moveUp == true)
        {
            outOfBounds.position = Vector3.MoveTowards(outOfBounds.position, finalOutOfBoundsPosition, moveSpeed * Time.deltaTime);
            hook.transform.position = Vector3.MoveTowards(hook.transform.position, finalHookPosition, moveSpeed * Time.deltaTime);
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, finalCameraPosition, moveSpeed * Time.deltaTime);
        }
        if (outOfBounds.position == finalOutOfBoundsPosition && hook.transform.position == finalHookPosition && mainCamera.transform.position == finalCameraPosition)
            moveUp = false;
    }
    
    // For some reason the wobble effect is not working.
    // Need to further look into it
    // A lot of time has wasted here, time to move on to next section.
    private void TowerWobbleEffect()
    {
        // Increase wobble force and torque based on block count
        float wobbleForceModified = wobbleForce + blockCount * wobbleIncrement;
        float wobbleTorqueModified = wobbleTorque + blockCount * wobbleIncrement;

        // Apply random force to the tower's rigidbody
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        towerRigidbody.AddForce(new Vector2(x, y) * wobbleForceModified);

        // Apply random torque to the tower's rigidbody
        float torque = Random.Range(-1f, 1f);
        towerRigidbody.AddTorque(torque * wobbleTorqueModified);
    }
}
