using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float sensitivityX = 2F;
    float sensitivityY = 2F;
    float minimumY = -90.0f;
    float maximumY = 90.0f;
    float rotationY;
    float rotationX;

    //Zoom
    float zoomSpeed = 10f;
    float maxFov = 60f;
    float minFov = 20f;

    private bool clicked = false;

    void Start()
    {
        Cursor.visible = true;
        rotationY = -transform.rotation.eulerAngles.x;
        rotationX = transform.rotation.eulerAngles.y;
    }

    //Update rotation of camera
    void Update()
    {
        sensitivityX = HelpPanel.sensitivity;
        sensitivityY = HelpPanel.sensitivity;

        if (!Exhibit.exhibitSelected && !HelpPanel.panelOpened)
        {
            if (clicked)
            {
                rotationX += Input.GetAxis("Mouse X") * sensitivityX;
                rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
                rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            }

            if (Input.GetMouseButtonDown(0))
            {
                clicked = true;//!clicked;
                Cursor.visible = !clicked;
            }
            if (Input.GetMouseButtonUp(0))
            {
                clicked = false;//!clicked;
                Cursor.visible = !clicked;
            }

            //Zoom
            float fov = Camera.main.fieldOfView;

            if (Input.GetKey(KeyCode.I))
            {
                fov -= 0.18f;
                fov = Mathf.Clamp(fov, minFov, maxFov);
                Camera.main.fieldOfView = fov;
            }

            if (Input.GetKey(KeyCode.O))
            {
                fov += 0.18f;
                fov = Mathf.Clamp(fov, minFov, maxFov);
                Camera.main.fieldOfView = fov;
            }

            fov -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            fov = Mathf.Clamp(fov, minFov, maxFov);
            Camera.main.fieldOfView = fov;
        }
    }
}
