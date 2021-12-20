using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisheController : MonoBehaviour
{
    Animator animator;

    Quaternion targetRotation;

    void Awake()
    {
        // コンポーネント関連付け
        TryGetComponent(out animator);

        // 初期化
        targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // 入力ベクトルの取得
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
        var velocity = horizontalRotation * new Vector3(horizontal, 0, vertical).normalized;

        // 速度の取得
        var speed = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
        var rotationSpeed = 600 * Time.deltaTime;

        // 移動方向を向く
        if (velocity.magnitude > 0.5f)
        {
            transform.rotation = Quaternion.LookRotation(velocity, Vector3.up);
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);

        // 移動速度をAnimatorに反映
        Debug.Log("velocity.magnitude * speed :" + velocity.magnitude * speed);
        animator.SetFloat("Speed", velocity.magnitude * speed, 0.1f, Time.deltaTime);
    }
}
