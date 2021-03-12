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

    void Start()
    {
        exhibitSelected = false;
    }

    void OnMouseDown()
    {
        //if exhibit is not selected, open selected exhibit
        if(!exhibitSelected && storiesDone)
        {
            mainPanel.SetActive(true);
            exhibitSelected = true;
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
        else if(linkCollider != null)
            linkCollider.SetActive(false);
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
    }

    public void exit()
    {
        mainPanel.SetActive(false);
        exhibitSelected = false;
        postProcessing.weight = 0; //deactivate depth of field
    }
}
