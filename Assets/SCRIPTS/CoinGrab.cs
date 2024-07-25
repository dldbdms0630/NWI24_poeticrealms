using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGrab : MonoBehaviour
{
    public bool isGrabbed = false;
    private Transform originalParent;
    private Collider coinCollider;
    private Rigidbody rb;
    public GameObject particles;
    public AudioClip sound;
    
    void Start()
    {
        coinCollider = GetComponent<Collider>();
        originalParent = transform.parent;
        rb = GetComponent<Rigidbody>();
        particles.SetActive(false);
    }

    

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Well") && !isGrabbed)
        {
            Debug.Log("tossed into the well!!");
            particles.SetActive(true);
        }
    }
}
