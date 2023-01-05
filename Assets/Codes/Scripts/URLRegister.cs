using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLRegister : MonoBehaviour
{
    public string URL;

    public void GoToURL()
    {
        Application.OpenURL(URL);
    }
}
