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
