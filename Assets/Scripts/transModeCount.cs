using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transModeCount : MonoBehaviour
{
    public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "two":
                PlayerPrefs.SetString("keyCount", "Two");
                break;
            case "four":
                PlayerPrefs.SetString("keyCount", "Four");
                break;
            case "six":
                PlayerPrefs.SetString("keyCount", "Six");
                break;
        }
        SceneManager.LoadScene("sceneChooseAI");
    }
}
