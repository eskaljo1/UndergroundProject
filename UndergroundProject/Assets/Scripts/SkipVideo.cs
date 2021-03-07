using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipVideo : MonoBehaviour
{
    public int numberOfVideos;
    public GameObject[] videoObjects;

    void OnMouseDown()
    {
        if (!Exhibit.exhibitSelected)
        {
            videoObjects[videoObjects.Length - numberOfVideos].SetActive(false);
            numberOfVideos--;
            if (numberOfVideos == 0)
                gameObject.SetActive(false);
            else
                videoObjects[videoObjects.Length - numberOfVideos].SetActive(true);
        }
    }
}
