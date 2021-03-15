using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipVideo : MonoBehaviour
{
    public int numberOfVideos;
    public GameObject[] videoObjects;
    public GameObject[] skipPositions;

    public void OnMouseDown()
    {
        if (!Exhibit.exhibitSelected)
        {
            videoObjects[videoObjects.Length - numberOfVideos].SetActive(false);
            numberOfVideos--;

            if (numberOfVideos <= 0)
            {
                gameObject.SetActive(false);
                Exhibit.storiesDone = true;
            }
            else
            {
                videoObjects[videoObjects.Length - numberOfVideos].SetActive(true);
                transform.position = skipPositions[videoObjects.Length - numberOfVideos].transform.position;
                transform.rotation = skipPositions[videoObjects.Length - numberOfVideos].transform.rotation;
            }

        }
    }
}
