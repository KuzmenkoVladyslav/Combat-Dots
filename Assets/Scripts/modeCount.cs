using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class modeCount : MonoBehaviour
{
    private Text title;

    private string lang;

    private List<string> arrayText = new List<string>();

    private void Start()
    {
        lang = PlayerPrefs.GetString("keyLang");
        title = GameObject.Find("modeName").GetComponent<Text>();

        if (lang.Equals("Ukrainian"))
        {
            uaRules uatxt = (uaRules)FindObjectOfType(typeof(uaRules));
            for (int i = 0; i < uatxt.UkrTittles.Length; i++)
            {
                arrayText.Add(uatxt.UkrTittles[i]);
            }
        }

        if (lang.Equals("Russian"))
        {
            ruRules rutxt = (ruRules)FindObjectOfType(typeof(ruRules));
            for (int i = 0; i < rutxt.RusTittles.Length; i++)
            {
                arrayText.Add(rutxt.RusTittles[i]);
            }
        }

        if (lang.Equals("English"))
        {
            enRules entxt = (enRules)FindObjectOfType(typeof(enRules));
            for (int i = 0; i < entxt.EngTittles.Length; i++)
            {
                arrayText.Add(entxt.EngTittles[i]);
            }
        }

        title.text = arrayText[15];
    }
}
