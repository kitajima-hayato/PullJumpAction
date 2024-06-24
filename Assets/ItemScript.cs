using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource=gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void DestorySelf()
    {
        Destroy(gameObject);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Get");
        audioSource.Play();
        //Debug.Log("�ڐG����\n");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("�ڐG���Ă���\n");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("���E����\n");
    }
}
