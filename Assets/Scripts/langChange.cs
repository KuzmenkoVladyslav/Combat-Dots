using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class langChange : MonoBehaviour
{
    [SerializeField]
    private GameObject panelLang;
    [SerializeField]
    private GameObject hide3;

    public GameObject Hide3 { get => hide3; set => hide3 = value; }
    public GameObject PanelLang { get => panelLang; set => panelLang = value; }

    private void OnMouseUpAsButton()
    {
        Hide3.SetActive(false);
        PanelLang.SetActive(true);
    }
}
