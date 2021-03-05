using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{
    public string sceneNumber;

    //Open scene
    void OpenScene()
    {
        //Return to menu scene
        if(sceneNumber == "0")
        {
            SceneManager.LoadScene("MenuScene");
            return;
        }

        //Moving from scene S1.1 to S1.2
        if(sceneNumber == "6")
        {
            SceneManager.LoadScene("S1.2");
            return;
        }

        //Rest of the scenes
        string s = "S" + sceneNumber;
        if (sceneNumber == "1")
            s = s + ".1";
        SceneManager.LoadScene(s);
    }

    void OnMouseDown()
    {
        if(Cursor.visible)
            OpenScene();
    }
}
