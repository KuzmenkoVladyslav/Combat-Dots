using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settTheme : MonoBehaviour
{
    [SerializeField]
    private GameObject themeLight;
    [SerializeField]
    private GameObject themeDark;

    private string theme;

    private void Update()
    {
        theme = PlayerPrefs.GetString("keyTheme");

        if (theme == "light")
        {
            themeLight.SetActive(true);
            themeDark.SetActive(false);
        }
        else
        {
            themeLight.SetActive(false);
            themeDark.SetActive(true);
        }
    }
}
