using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHover : MonoBehaviour
{
    public GameObject name;

    void Start()
    {
        Cursor.visible = true;
    }

    void OnMouseOver()
    {
        name.SetActive(true);
    }

    void OnMouseExit()
    {
        name.SetActive(false);
    }
}
