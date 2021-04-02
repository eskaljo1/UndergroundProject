using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Exhibit : MonoBehaviour
{
    public PostProcessVolume postProcessing;
    public Camera camera; //main camera
    
    public static bool exhibitSelected = false; //used to stop movement
    public static bool storiesDone = false; //true if all videos skipped or done

    //Canvas info (next script)
    public Sprite[] slajdovi;
    public GameObject mainPanel;
    public GameObject panel;
    private int brojac = 0;
    public GameObject prev;
    public GameObject nextButton;

    public int linkSlideNumber = -1;
    public GameObject linkCollider;

    public GameObject namePanel;
    public Canvas canvas;
    private Vector2 canvasPos;
    private RectTransform canvasRect;
    public Text nameText;
    public string nameOfLink;

    public bool handLinkS3 = false;
    public GameObject video1;
    public GameObject video2;
    public GameObject video3;
    public GameObject video4;
    public GameObject raw1;
    public GameObject raw2;
    public GameObject raw3;
    public GameObject raw4;

    public float offset = 0.25f;

    void Start()
    {
        canvasPos = canvas.transform.position;
        canvasRect = canvas.GetComponent<RectTransform>();
        exhibitSelected = false;
    }

    void OnMouseOver()
    {
        if (!exhibitSelected)
        {
            float offsetPosY = transform.position.y + offset;
            Vector3 offsetPos = new Vector3(transform.position.x, offsetPosY, transform.position.z);

            // Calculate *screen* position (note, not a canvas/recttransform position)
            Vector2 screenPoint = Camera.main.WorldToScreenPoint(offsetPos);

            // Convert screen position to Canvas / RectTransform space <- leave camera null if Screen Space Overlay
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, null, out canvasPos);

            // Set
            namePanel.transform.localPosition = canvasPos;

            namePanel.SetActive(true);
            nameText.text = nameOfLink;
        }
    }

    void OnMouseExit()
    {
        if(!exhibitSelected)
            namePanel.SetActive(false);
    }

    void OnMouseDown()
    {
        //if exhibit is not selected, open selected exhibit
        if (!exhibitSelected && !HelpPanel.panelOpened /* && storiesDone*/)
        {
            mainPanel.SetActive(true);
            exhibitSelected = true;
            namePanel.SetActive(false);
            postProcessing.weight = 1; //activate depth of field
            
        }
    }

    public void nextSlajd()
    {
        brojac++;
        panel.GetComponent<Image>().sprite = slajdovi[brojac];
        if (brojac == slajdovi.Length - 1) nextButton.SetActive(false);
        if (brojac != 0) prev.SetActive(true);
        if (brojac == linkSlideNumber)
            linkCollider.SetActive(true);
        else if (linkCollider != null)
            linkCollider.SetActive(false);

        if (handLinkS3)
        {
            if (slajdovi[brojac] == null)
            {
                panel.SetActive(false);
                switch (brojac)
                {
                    case 1:
                        video1.SetActive(true);
                        video2.SetActive(false);
                        video3.SetActive(false);
                        video4.SetActive(false);
                        raw1.SetActive(true);
                        raw2.SetActive(false);
                        raw3.SetActive(false);
                        raw4.SetActive(false);
                        break;
                    case 2:
                        video1.SetActive(false);
                        video2.SetActive(true);
                        video3.SetActive(false);
                        video4.SetActive(false);
                        raw1.SetActive(false);
                        raw2.SetActive(true);
                        raw3.SetActive(false);
                        raw4.SetActive(false);
                        break;
                    case 3:
                        video1.SetActive(false);
                        video2.SetActive(false);
                        video3.SetActive(true);
                        video4.SetActive(false);
                        raw1.SetActive(false);
                        raw2.SetActive(false);
                        raw3.SetActive(true);
                        raw4.SetActive(false);
                        break;
                    case 4:
                        video1.SetActive(false);
                        video2.SetActive(false);
                        video3.SetActive(false);
                        video4.SetActive(true);
                        raw1.SetActive(false);
                        raw2.SetActive(false);
                        raw3.SetActive(false);
                        raw4.SetActive(true);
                        break;
                }
            }
            else
            {
                panel.SetActive(true);
                video1.SetActive(false);
                video2.SetActive(false);
                video3.SetActive(false);
                video4.SetActive(false);
                raw1.SetActive(false);
                raw2.SetActive(false);
                raw3.SetActive(false);
                raw4.SetActive(false);
            }
        }
    }

    public void prevSlajd()
    {
        brojac--;
        panel.GetComponent<Image>().sprite = slajdovi[brojac];
        if (brojac == 0) prev.SetActive(false);
        if (brojac != slajdovi.Length - 1) nextButton.SetActive(true);
        if (brojac == linkSlideNumber)
            linkCollider.SetActive(true);
        else if (linkCollider != null)
            linkCollider.SetActive(false);

        if (handLinkS3)
        {
            if (slajdovi[brojac] == null)
            {
                panel.SetActive(false);
                switch (brojac)
                {
                    case 1:
                        video1.SetActive(true);
                        video2.SetActive(false);
                        video3.SetActive(false);
                        video4.SetActive(false);
                        raw1.SetActive(true);
                        raw2.SetActive(false);
                        raw3.SetActive(false);
                        raw4.SetActive(false);
                        break;
                    case 2:
                        video1.SetActive(false);
                        video2.SetActive(true);
                        video3.SetActive(false);
                        video4.SetActive(false);
                        raw1.SetActive(false);
                        raw2.SetActive(true);
                        raw3.SetActive(false);
                        raw4.SetActive(false);
                        break;
                    case 3:
                        video1.SetActive(false);
                        video2.SetActive(false);
                        video3.SetActive(true);
                        video4.SetActive(false);
                        raw1.SetActive(false);
                        raw2.SetActive(false);
                        raw3.SetActive(true);
                        raw4.SetActive(false);
                        break;
                    case 4:
                        video1.SetActive(false);
                        video2.SetActive(false);
                        video3.SetActive(false);
                        video4.SetActive(true);
                        raw1.SetActive(false);
                        raw2.SetActive(false);
                        raw3.SetActive(false);
                        raw4.SetActive(true);
                        break;
                }
            }
            else
            {
                panel.SetActive(true);
                video1.SetActive(false);
                video2.SetActive(false);
                video3.SetActive(false);
                video4.SetActive(false);
                raw1.SetActive(false);
                raw2.SetActive(false);
                raw3.SetActive(false);
                raw4.SetActive(false);
            }
        }
    }

    public void exit()
    {
        mainPanel.SetActive(false);
        exhibitSelected = false;
        postProcessing.weight = 0; //deactivate depth of field
    }
}
