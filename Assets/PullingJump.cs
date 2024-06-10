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
        Debug.Log("ÚG‚µ‚½\n");
    }
    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("ÚG’†\n");
        isCanJump = true;
        //Õ“Ë‚µ‚Ä‚¢‚é“_‚Ìî•ñ‚ª•¡”Ši”[‚³‚ê‚Ä‚¢‚é
        ContactPoint[] contacts = collision.contacts;
        //‚O”Ô–Ú‚ÌÕ“Ëî•ñ‚©‚çAÕ“Ë‚µ‚Ä‚¢‚é“_‚Ì–@ü‚Ìæ“¾
        Vector3 otherNormal = contacts[0].normal;
        //ã•ûŒü‚ğ¦‚·ƒxƒNƒgƒ‹B’·‚³‚Í‚P
        Vector3 upVector = new Vector3(0, 1, 0);
        //ã•ûŒü‚Æ–@ü‚Ì“àÏB‚Q‚Â‚Ì”“k‚é‚Í‚Æ‚à‚É’·‚³‚ª‚PBcosƒÆ‚ÌŒ‹‰Ê‚ª“ü‚é
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
        //Debug.Log("—£’E‚µ‚½\n");
        isCanJump=false;
    }

    
}
