using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fontTheme : MonoBehaviour
{
    [SerializeField]
    private Text first;
    [SerializeField]
    private Text second;    

    private string theme;

    void Update()
    {
        theme = PlayerPrefs.GetString("keyTheme");

        if (theme == "light")
        {
            first.color = Color.red;
            second.color = Color.blue;
        }
        else
        {
            first.color = Color.yellow;
            second.color = Color.cyan;
        }
    }
}
