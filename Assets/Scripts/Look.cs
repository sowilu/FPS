using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Look : MonoBehaviour
{
    private float upDownRotation;
    public Transform camera;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

   
    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        
        upDownRotation -= mouseY;
        upDownRotation = Mathf.Clamp(upDownRotation, -90f, 90f);
        
        camera.localRotation = Quaternion.Euler(upDownRotation, 0, 0);
        transform.Rotate(0, mouseX, 0);
    }
}
