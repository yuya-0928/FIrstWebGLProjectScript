using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class move : MonoBehaviour
{
    public float speed = 6.0f; // ï‡çsë¨ìx
    public float jumpspeed = 8.0f;
    public float gravity = 20.0f;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float h, v;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(h, 0, v);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpspeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        
        //if (Input.GetKey("w"))
        //{
        //    Debug.Log("move forward");
        //    transform.position += Vector3.forward;
        //}
        
        //if (Input.GetKey("a"))
        //{
        //    Debug.Log("move left");
        //    transform.position += Vector3.left;
        //}

        //if (Input.GetKey("s"))
        //{
        //    Debug.Log("move back");
        //    transform.position += Vector3.back;
        //}
        //if (Input.GetKey("d"))
        //{
        //    Debug.Log("move right");
        //    transform.position += Vector3.right;
        //}


        DownKeyCheck();
    }

    void DownKeyCheck()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    Debug.Log(code);
                }
            }
        }
    }
}
