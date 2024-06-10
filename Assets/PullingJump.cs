using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;
    private bool isCanJump;
    // Start is called before the first frame update
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (isCanJump&&Input.GetMouseButtonUp(0))
        {
            //
            Vector3 dist = clickPosition - Input.mousePosition;
            //
            if (dist.sqrMagnitude == 0) { return; }
            //
            rb.velocity = dist.normalized * jumpPower;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("�ڐG����\n");
    }
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("�ڐG��\n");
        isCanJump = true;
        //�Փ˂��Ă���_�̏�񂪕����i�[����Ă���
        ContactPoint[] contacts = collision.contacts;
        //�O�Ԗڂ̏Փˏ�񂩂�A�Փ˂��Ă���_�̖@���̎擾
        Vector3 otherNormal = contacts[0].normal;
        //������������x�N�g���B�����͂P
        Vector3 upVector = new Vector3(0, 1, 0);
        //������Ɩ@���̓��ρB�Q�̔��k��͂Ƃ��ɒ������P�Bcos�Ƃ̌��ʂ�����
        float dotUN = Vector3.Dot(upVector, otherNormal);
        //
        float dotDeg = Mathf.Acos(dotUN) * Mathf.Rad2Deg;
        //
        if(dotDeg <=45) {
            isCanJump = true;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("���E����\n");
        isCanJump=false;
    }

    
}
