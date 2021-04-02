using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpPanel : MonoBehaviour
{
    public Slider slider;
    public static float sensitivity = 2f;
    public static bool panelOpened = false;
    public GameObject exitPanel;

    void Awake()
    {
        slider.value = sensitivity;
    }

    public void ExitHelp()
    {
        panelOpened = false;
        gameObject.SetActive(false);
    }

    public void OpenHelp()
    {
        if (!Exhibit.exhibitSelected)
        {
            panelOpened = true;
            Cursor.visible = true;
            gameObject.SetActive(true);
        }
    }

    public void ChangeSensitivity()
    {
        sensitivity = slider.value;
    }

    public void exitApp()
    {
        Application.Quit();
    }
    
    public void openExitPanel()
    {
        exitPanel.SetActive(true);
    }
}
