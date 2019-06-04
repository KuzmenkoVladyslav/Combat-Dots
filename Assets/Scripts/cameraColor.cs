using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraColor : MonoBehaviour
{
    [SerializeField]
    private GameObject lightBack;
    [SerializeField]
    private GameObject darkBack;
    private Camera cam;
    private string theme;

    void Start()
    {
        cam = GetComponent<Camera>();        
    }

    private void Update()
    {
        theme = PlayerPrefs.GetString("keyTheme");

        if (!theme.Equals("light") && !theme.Equals("dark"))
        {
            theme = "light";
        }

        if (theme == "light")
        {
            cam.backgroundColor = new Color32(173, 185, 204, 255);
            lightBack.SetActive(true);
            darkBack.SetActive(false);
        }
        else
        {
            cam.backgroundColor = new Color32(62, 69, 80, 255);
            lightBack.SetActive(false);
            darkBack.SetActive(true);
        }
    }

}
