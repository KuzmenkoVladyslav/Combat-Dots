using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class diffSet : MonoBehaviour
{
    [SerializeField]
    private string buttonDifficult;

    public void OnMouseUpAsButton()
    {
        switch (buttonDifficult)
        {

            case "Very easy":
                PlayerPrefs.SetString("keyDiff", "VE");
                break;

            case "Easy":
                PlayerPrefs.SetString("keyDiff", "E");
                break;

            case "Medium":
                PlayerPrefs.SetString("keyDiff", "M");
                break;

            case "Hard":
                PlayerPrefs.SetString("keyDiff", "H");
                break;

            case "Impossible":
                PlayerPrefs.SetString("keyDiff", "VH");
                break;
        }
        SceneManager.LoadScene("sceneSingle");
    }
}
