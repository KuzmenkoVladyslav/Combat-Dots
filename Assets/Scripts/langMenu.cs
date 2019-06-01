using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class langMenu : MonoBehaviour
{
    private Text title, single, multi, setting, quit;

    private string lang;

    private List<string> arrayText = new List<string>();

    private void Start()
    {
        lang = PlayerPrefs.GetString("keyLang");
        title = GameObject.Find("gameName").GetComponent<Text>();
        single = GameObject.Find("menuAI").GetComponent<Text>();
        multi = GameObject.Find("menuPVP").GetComponent<Text>();
        setting = GameObject.Find("menuOpt").GetComponent<Text>();
        quit = GameObject.Find("menuExit").GetComponent<Text>();

        if (lang.Equals("Ukrainian"))
        {
            uaRules uatxt = (uaRules)FindObjectOfType(typeof(uaRules));            
            for (int i = 0; i < uatxt.UkrTittles.Length-1; i++)
            {
                arrayText.Add(uatxt.UkrTittles[i]);
            }            
        }

        if (lang.Equals("Russian"))
        {
            ruRules rutxt = (ruRules)FindObjectOfType(typeof(ruRules));
            for (int i = 0; i < rutxt.RusTittles.Length-1; i++)
            {
                arrayText.Add(rutxt.RusTittles[i]);
            }
        }

        if (lang.Equals("English"))
        {
            enRules entxt = (enRules)FindObjectOfType(typeof(enRules));
            for (int i = 0; i < entxt.EngTittles.Length-1; i++)
            {
                arrayText.Add(entxt.EngTittles[i]);
            }
        }

        title.text = arrayText[0];
        single.text = arrayText[1];
        multi.text = arrayText[2];
        setting.text = arrayText[3];
        quit.text = arrayText[4];
    }
}
