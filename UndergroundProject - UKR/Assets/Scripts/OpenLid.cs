using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLid : MonoBehaviour
{
    private bool opened = false;
    public GameObject arrow;

    void OnMouseDown()
    {
        if (!opened)
        {
            opened = true;
            GetComponent<Animator>().SetBool("OpenLid", true);
            arrow.SetActive(false);
        }
    }
}
