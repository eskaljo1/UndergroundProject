using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class next : MonoBehaviour
{
    public PostProcessVolume postProcessing;
    public Sprite[] slajdovi;
    public GameObject panel;
    private int brojac = 0;
    public GameObject canvas;
    public GameObject prev;
    public GameObject nextButton;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextSlajd()
    {
        brojac++;
        panel.GetComponent<Image>().sprite = slajdovi[brojac];
        if(brojac == slajdovi.Length - 1) nextButton.SetActive(false);
        if(brojac != 0) prev.SetActive(true);
    }

    public void prevSlajd()
    {
        brojac--;
        panel.GetComponent<Image>().sprite = slajdovi[brojac];
        if(brojac == 0) prev.SetActive(false);  
        if(brojac != slajdovi.Length - 1) nextButton.SetActive(true);
    }

    public void exit()

    { 
        canvas.SetActive(false);
    }
 }
