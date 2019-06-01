using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnClick : MonoBehaviour
{
    private gameMulti Pole;

    private void Start()
    {
        Pole = FindObjectOfType<gameMulti>();
    }

    private void OnMouseUpAsButton()
    {
        Pole.Coordinates(transform.position.x, transform.position.y, transform.position.z);
    }
}