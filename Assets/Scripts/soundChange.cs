using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundChange : MonoBehaviour
{
    [SerializeField]
    private GameObject soundOn;
    [SerializeField]
    private GameObject soundOff;
    [SerializeField]
    private bool dir;

    private string sound;

    private void Start()
    {
        if (!PlayerPrefs.GetString("keySound").Equals("soundOff") && !PlayerPrefs.GetString("keySound").Equals("soundOn"))
        {
            PlayerPrefs.SetString("keySound", "soundOff");
        }
        sound = PlayerPrefs.GetString("keySound");
        if (sound.Equals("soundOff"))
        {
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }
        else
        {
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
    }

    private void OnMouseUpAsButton()
    {
        if (dir == true)
        {
            PlayerPrefs.SetString("keySound", "soundOff");
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetString("keySound", "soundOn");
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
    }
}
