using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform feet;
    public LayerMask groundMask;
    public float speed = 15;
    public float gravity = -9.8f;
    public float jumpHeight = 3;
    
    private CharacterController controller;
    private bool isGrounded;
    private float y;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(feet.position, 0.4f, groundMask);
        
        //cap gravity 
        if (isGrounded) y = 0;
        
        var input = new Vector3();
        input.x = Input.GetAxis("Horizontal");
        input.z = Input.GetAxis("Vertical");

        var move = (transform.right * input.x  + transform.forward * input.z) * speed * Time.deltaTime;
        
        //jump 
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            y = Mathf.Sqrt(jumpHeight * -2f * gravity) * Time.deltaTime;
        }
        
        //add gravity 
        y += gravity * Time.deltaTime * Time.deltaTime;
        move.y = y;
        
        controller.Move(move);
    }

    private void OnDrawGizmos()
    {
        if (feet != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(feet.position, 0.4f);
        }
    }
}
