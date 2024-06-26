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
        Debug.Log("接触した\n");
    }
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("接触中\n");
        isCanJump = true;
        //衝突している点の情報が複数格納されている
        ContactPoint[] contacts = collision.contacts;
        //０番目の衝突情報から、衝突している点の法線の取得
        Vector3 otherNormal = contacts[0].normal;
        //上方向を示すベクトル。長さは１
        Vector3 upVector = new Vector3(0, 1, 0);
        //上方向と法線の内積。２つの博徒るはともに長さが１。cosθの結果が入る
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
        //Debug.Log("離脱した\n");
        isCanJump=false;
    }

    
}
