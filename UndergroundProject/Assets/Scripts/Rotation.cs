using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public int rotationSpeed;
    public int typeOfRotation;

    // Update is called once per frame
    void Update()
    {
        switch(typeOfRotation)
        {
            case 1:
                transform.Rotate(rotationSpeed * Time.deltaTime, 0, 0);
                break;
            case 2:
                transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, 0);
                break;
            case 3:
                transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                break;
        }
    }
}
