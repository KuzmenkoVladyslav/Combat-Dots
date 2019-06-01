using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnChange : MonoBehaviour
{
    [SerializeField]
    bool dir;

    private void OnMouseUpAsButton()
    {
        helpArrows arrow = (helpArrows)FindObjectOfType(typeof(helpArrows));
        if (dir == true)
        {
            arrow.State--;
        }
        else
        {
            arrow.State++;
        }
    }
}
