using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class themeChange : MonoBehaviour
{
    [SerializeField]
    bool dir;

    private void OnMouseUpAsButton()
    {
        if (dir == true)
        {
            PlayerPrefs.SetString("keyTheme", "light");
        }
        else
        {
            PlayerPrefs.SetString("keyTheme", "dark");            
        }
    }
}