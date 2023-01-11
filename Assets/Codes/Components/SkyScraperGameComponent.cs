using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScraperGameComponent : MonoBehaviour
{
    public GameObject gameManager;

    private void OnEnable()
    {
        gameManager.SetActive(true);
    }

    private void OnDisable()
    {
        gameManager.SetActive(false);
    }
}
