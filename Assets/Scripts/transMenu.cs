using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transMenu : MonoBehaviour
{
    public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "PvsAI":
                SceneManager.LoadScene("sceneSingleMode");
                break;
            case "PvP":
                SceneManager.LoadScene("sceneMultiMode");
                break;
            case "Options":
                SceneManager.LoadScene("sceneSettings");
                break;
            case "Help":
                SceneManager.LoadScene("sceneHelp");
                break;
            case "Exit":
                Application.Quit();
                break;
            default:
                break;
        }
    }
}
