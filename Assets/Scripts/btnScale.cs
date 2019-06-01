using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnScale : MonoBehaviour
{
    private int state = 0;

    private void OnMouseOver()
    {
        if (state == 0) {
            transform.localScale = new Vector3(transform.localScale.x * 1.15F, transform.localScale.y * 1.15F, transform.localScale.z);
            state++;
        }  
    }

    private void OnMouseExit()
    {
        if (state == 1)
        {
            transform.localScale = new Vector3(transform.localScale.x / 1.15F, transform.localScale.y / 1.15F, transform.localScale.z);
            state--;
        }
    } 
}
