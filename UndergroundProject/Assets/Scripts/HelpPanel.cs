using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPanel : MonoBehaviour
{
    public void ExitHelp()
    {
        gameObject.SetActive(false);
    }

    public void OpenHelp()
    {
        gameObject.SetActive(true);
    }
}
