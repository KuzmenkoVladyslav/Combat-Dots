using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transModeMulti : MonoBehaviour
{
    public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "standart":
                PlayerPrefs.SetString("keyMode", "Standart");
                SceneManager.LoadScene("sceneMultiplayer");
                break;
            case "tactic":
                PlayerPrefs.SetString("keyMode", "Tactic");
                SceneManager.LoadScene("sceneMultiCount");
                break;
        }        
    }
}