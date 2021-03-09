using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Exhibit : MonoBehaviour
{
    public PostProcessVolume postProcessing;
    public Camera camera; //main camera

  //  public float  distance; //distance to place object in front of camera
    
    //private bool isSelected = false;
   // private bool _isRotating;
    public static bool exhibitSelected = false; //used to stop movement

    //initial position and rotation
   // private Vector3 initialPosition;
    //private Quaternion initialRotation;

    //for rotation
   // private float _sensitivity = 0.4f;
   // private Vector3 _mouseReference;
   // private Vector3 _mouseOffset;
   // private Vector3 _rotation = Vector3.zero;

    //Canvas info (next script)
    public Sprite[] slajdovi;
    public GameObject panel;
    private int brojac = 0;
    public GameObject prev;
    public GameObject nextButton;

    void Start()
    {
        exhibitSelected = false;
 //       initialPosition = gameObject.transform.position;
   //     initialRotation = gameObject.transform.rotation;
    }

    void OnMouseDown()
    {
        //if exhibit is not selected, open selected exhibit
        if(!exhibitSelected)
        {
            panel.SetActive(true);
            exhibitSelected = true;
           // isSelected = true;
            postProcessing.weight = 1; //activate depth of field
            //gameObject.transform.position = camera.transform.position + camera.transform.forward * distance;
            
        }
        //if exhibit is selected, close exhibit
     /*   else
        {
            //check if the pressed exhibit is the selected one
            if(isSelected)
            {
                canvas.SetActive(false);
                exhibitSelected = false;
                isSelected = false;
                postProcessing.weight = 0; //deactivate depth of field
               // gameObject.transform.position = initialPosition;
                //gameObject.transform.rotation = initialRotation;
            }
        }*/
    }
    /*
    void Update()
    {
        if (exhibitSelected && isSelected)
        {
            if (_isRotating)
            {
                // offset
                _mouseOffset = (Input.mousePosition - _mouseReference);

                // apply rotation
                _rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;

                // rotate
                transform.Rotate(_rotation);

                // store mouse
                _mouseReference = Input.mousePosition;
            }
            if (Input.GetMouseButtonDown(1))
            {
                // rotating flag
                _isRotating = true;

                // store mouse
                _mouseReference = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(1))
            {
                // rotating flag
                _isRotating = false;
            }
        }
    }*/

    public void nextSlajd()
    {
        brojac++;
        panel.GetComponent<Image>().sprite = slajdovi[brojac];
        if (brojac == slajdovi.Length - 1) nextButton.SetActive(false);
        if (brojac != 0) prev.SetActive(true);
    }

    public void prevSlajd()
    {
        brojac--;
        panel.GetComponent<Image>().sprite = slajdovi[brojac];
        if (brojac == 0) prev.SetActive(false);
        if (brojac != slajdovi.Length - 1) nextButton.SetActive(true);
    }

    public void exit()
    {
        panel.SetActive(false);
        exhibitSelected = false;
        postProcessing.weight = 0; //deactivate depth of field
    }
}
