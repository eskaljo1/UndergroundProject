using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivityX = 8F;
    public float sensitivityY = 8F;
    public float minimumY = -90.0f;
    public float maximumY = 90.0f;
    float rotationY = 0.0f;
    float rotationX = 180.0f;

    private bool clicked = false;

    void Start()
    {
        Cursor.visible = true;
    }

    //Update rotation of camera
    void Update()
    {
        if (clicked)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }

        if(Input.GetMouseButtonDown(1))
        {
            clicked = true;//!clicked;
            Cursor.visible = !clicked;
        }
        if(Input.GetMouseButtonUp(1))
        {
            clicked = false;//!clicked;
            Cursor.visible = !clicked;
        }
    }
}
