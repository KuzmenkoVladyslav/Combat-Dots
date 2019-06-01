using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainStart : MonoBehaviour
{   
    [SerializeField]
    private string buttonLanguage;

    public void Start()
    {
        if (!PlayerPrefs.GetString("keyTheme").Equals("light") && !PlayerPrefs.GetString("keyTheme").Equals("dark"))
        {
            PlayerPrefs.SetString("keyTheme", "light");
        }        
    }

    public void OnMouseUpAsButton()
    {       
        switch (buttonLanguage)
        {
            case "UA":
                PlayerPrefs.SetString("keyLang", "Ukrainian");                
                break;

            case "RU":
                PlayerPrefs.SetString("keyLang", "Russian");
                break;

            case "USA":
                PlayerPrefs.SetString("keyLang", "English");
                break;
        }

        SceneManager.LoadScene("sceneMain");
    }
}
