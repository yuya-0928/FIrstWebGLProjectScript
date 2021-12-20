using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using System;

public class MoveMishe : MonoBehaviour
{
    public float speed = 6.0f; // 歩行速度
    public float jumpspeed = 8.0f;
    public float gravity = 20.0f;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private float h, v;
    public GameObject cinema_camera;

    [SerializeField] AxisState Horizontal;
    [SerializeField] AxisState Vertical;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    // キャラクターの移動
    void Update()
    {

        // 入力の取得
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var velocity = new Vector3(horizontal, 0, vertical).normalized;
        var speed = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;

        //var leftStick = new Vector3(inputX, 0, inputY).normalized;
        Horizontal.Update(Time.deltaTime);
        Vertical.Update(Time.deltaTime);

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(horizontal, 0, vertical).normalized;
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpspeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        

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
