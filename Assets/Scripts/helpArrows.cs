using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helpArrows : MonoBehaviour
{  
    private int state = 1;
    private Text rules,title;
    [SerializeField]
    private GameObject leftArrow;
    [SerializeField]
    private GameObject rightArrow;
    [SerializeField]
    private GameObject ruleFirst;
    [SerializeField]
    private GameObject ruleSecond;
    [SerializeField]
    private GameObject ruleThird;
    private List<string> arrayText = new List<string>();

    public int State { get => state; set => state = value; }

    private string lang;

    private void Start()
    {
        lang = PlayerPrefs.GetString("keyLang");
        title = GameObject.Find("helpTittle").GetComponent<Text>();
        rules = GameObject.Find("helpRules").GetComponent<Text>();
        
        if (lang.Equals("Ukrainian"))
        {            
            uaRules uatxt = (uaRules)FindObjectOfType(typeof(uaRules));
            title.text = uatxt.UkrTittles[5];
            for (int i = 0; i < uatxt.UkrText.Length; i++) {
                arrayText.Add(uatxt.UkrText[i]);
            }
        }
        if (lang.Equals("Russian"))
        {
            ruRules rutxt = (ruRules)FindObjectOfType(typeof(ruRules));
            title.text = rutxt.RusTittles[5];
            for (int i = 0; i < rutxt.RusText.Length; i++)
            {
                arrayText.Add(rutxt.RusText[i]);
            }
        }
        if (lang.Equals("English"))
        {
            enRules entxt = (enRules)FindObjectOfType(typeof(enRules));
            title.text = entxt.EngTittles[5];
            for (int i = 0; i < entxt.EngText.Length; i++)
            {
                arrayText.Add(entxt.EngText[i]);
            }
        }
    }

    private void Hidden_img() {
        ruleFirst.SetActive(false);
        ruleSecond.SetActive(false);
        ruleThird.SetActive(false);
    }

    private void Update() {
        Hidden_img();
        switch (State)
        {
            case 1:
                rules.text = arrayText[0];
                break;

            case 2:
                rules.text = arrayText[1];
                ruleFirst.SetActive(true);
                break;

            case 3:
                rules.text = arrayText[2];
                break;

            case 4:
                rules.text = arrayText[3];
                ruleSecond.SetActive(true);
                break;

            case 5:
                rules.text = arrayText[4];
                break;

            case 6:
                rules.text = arrayText[5];
                break;

            case 7:
                rules.text = arrayText[6];
                ruleThird.SetActive(true);
                break;

            case 8:
                rules.text = arrayText[7];
                break;

            case 9:
                rules.text = arrayText[8];
                break;

            case 10:
                rules.text = arrayText[9];
                break;

            case 11:
                rules.text = arrayText[10];
                break;

            case 12:
                rules.text = arrayText[11];
                break;

            case 13:
                rules.text = arrayText[12];
                break;
        }

        if (State == 13)
        {
            rightArrow.SetActive(false);
        }
        else
        {
            rightArrow.SetActive(true);
        }

        if (State == 1)
        {
            leftArrow.SetActive(false);
        }
        else
        {
            leftArrow.SetActive(true);
        }
    }
}