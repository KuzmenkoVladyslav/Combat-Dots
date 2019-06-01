using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelsText : MonoBehaviour
{
    [SerializeField]
    private Text very_easy;
    [SerializeField]
    private Text easy;
    [SerializeField]
    private Text medium;
    [SerializeField]
    private Text hard;
    [SerializeField]
    private Text very_hard;

    private string lang;

    void Start()
    {
        lang = PlayerPrefs.GetString("keyLang");

        if (lang.Equals("Ukrainian"))
        {
            uaRules uatxt = (uaRules)FindObjectOfType(typeof(uaRules));
            very_easy.text = uatxt.UkrTittles[7];
            easy.text = uatxt.UkrTittles[8];
            medium.text = uatxt.UkrTittles[9];
            hard.text = uatxt.UkrTittles[10];
            very_hard.text = uatxt.UkrTittles[11];
        }
        if (lang.Equals("Russian"))
        {
            ruRules rutxt = (ruRules)FindObjectOfType(typeof(ruRules));            
            very_easy.text = rutxt.RusTittles[7];
            easy.text = rutxt.RusTittles[8];
            medium.text = rutxt.RusTittles[9];
            hard.text = rutxt.RusTittles[10];
            very_hard.text = rutxt.RusTittles[11];
        }
        if (lang.Equals("English"))
        {
            enRules entxt = (enRules)FindObjectOfType(typeof(enRules));
            very_easy.text = entxt.EngTittles[7];
            easy.text = entxt.EngTittles[8];
            medium.text = entxt.EngTittles[9];
            hard.text = entxt.EngTittles[10];
            very_hard.text = entxt.EngTittles[11];
        }
    }
}
