using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisheController : MonoBehaviour
{
    Animator animator;

    Quaternion targetRotation;

    void Awake()
    {
        // �R���|�[�l���g�֘A�t��
        TryGetComponent(out animator);

        // ������
        targetRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // ���̓x�N�g���̎擾
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var horizontalRotation = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
        var velocity = horizontalRotation * new Vector3(horizontal, 0, vertical).normalized;

        // ���x�̎擾
        var speed = Input.GetKey(KeyCode.LeftShift) ? 2 : 1;
        var rotationSpeed = 600 * Time.deltaTime;

        // �ړ�����������
        if (velocity.magnitude > 0.5f)
        {
            transform.rotation = Quaternion.LookRotation(velocity, Vector3.up);
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);

        // �ړ����x��Animator�ɔ��f
        Debug.Log("velocity.magnitude * speed :" + velocity.magnitude * speed);
        animator.SetFloat("Speed", velocity.magnitude * speed, 0.1f, Time.deltaTime);
    }
}
