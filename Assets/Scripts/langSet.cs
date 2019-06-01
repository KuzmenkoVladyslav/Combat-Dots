using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class langSet : MonoBehaviour
{
    [SerializeField]
    private string buttonLanguage;   

    private void OnMouseUpAsButton()
    {
        switch (buttonLanguage) {

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

        langChange obj = (langChange)FindObjectOfType(typeof(langChange));
        obj.Hide3.SetActive(true);
        obj.PanelLang.SetActive(false);
    }
}
