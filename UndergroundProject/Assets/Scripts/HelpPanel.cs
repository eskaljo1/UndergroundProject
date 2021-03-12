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
        if (!Exhibit.exhibitSelected)
            gameObject.SetActive(true);
    }
}
