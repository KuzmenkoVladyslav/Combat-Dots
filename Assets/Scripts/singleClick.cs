using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singleClick : MonoBehaviour
{
    private gameSingle PoleSingle;

    private void Start()
    {
        PoleSingle = FindObjectOfType<gameSingle>();
    }

    private void OnMouseUpAsButton()
    {
        PoleSingle.CoordinatesSingle(transform.position.x, transform.position.y, transform.position.z);
    }
}