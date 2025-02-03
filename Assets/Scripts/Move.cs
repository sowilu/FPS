using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform feet;
    public float speed = 10;
    public float gravity = -9.8f;
    public float jumpHeight = 2;
    
    private CharacterController controller;
    private float y;
    private bool isGrounded;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(feet.position, 0.4f, groundLayer);

        if (isGrounded) y = 0;
        
        var x = Input.GetAxisRaw("Horizontal");
        var z = Input.GetAxisRaw("Vertical");
        
        var move = (transform.right * x + transform.forward * z) * speed * Time.deltaTime;
        
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
            Gizmos.DrawSphere(feet.position, 0.4f);
        }
    }
}
