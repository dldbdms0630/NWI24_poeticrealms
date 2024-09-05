using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CoinGrab : MonoBehaviour
{
    public bool isGrabbed = false;
    public bool inZone = true;
    public GameObject wishingWell; 
    //private Transform originalParent;
    //private Collider coinCollider;
    private XRGrabInteractable grabInteractable;


    private Rigidbody rb;
    private Vector3 SpawnPosition;
    public GameObject particles;
    private AudioSource coinSound;
    private AudioSource wishingSound;


    void Start()
    {
        //coinCollider = GetComponent<Collider>();
        //originalParent = transform.parent;
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
            grabInteractable.selectExited.AddListener(OnReleased);
        }

        rb = GetComponent<Rigidbody>();
        particles.SetActive(false);
        coinSound = gameObject.GetComponent<AudioSource>();
        SpawnPosition = new Vector3(54.87f, 1.48f, 61.75f);
        // SpawnPosition = new Vector3(66.0f, 1.48f, 63f);
        wishingSound = wishingWell.GetComponent<AudioSource>();

        //SpawnPosition = new Vector3(50.05f, 0.73f, 62.59f);
    }

    void Update()
    {
        /*if(transform.position.y <= -3) {
            Debug.Log("-3 height respawn");
            Respawn();
        }*/

        if (!inZone && !isGrabbed)
        {
            Debug.Log("not in zone and not grabbed respawn ");
            Respawn();
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        isGrabbed = true;
        Debug.Log($"{gameObject.name} is grabbed.");
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        isGrabbed = false;
        Debug.Log($"{gameObject.name} is released.");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Well") && !isGrabbed)
        {
            Debug.Log("tossed into the well!!");
            particles.SetActive(true);
            wishingSound.Play();
        }
        if (other.CompareTag("Respawn"))
        {
            Debug.Log("enter zone ");
            inZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            Debug.Log("exit zone");
            inZone = false;
        }
    }

    public void Respawn()
    {
        Debug.Log("RESPAWNING!!! ");
        //particles.SetActive(true);

        inZone = true;
        isGrabbed = false;

        coinSound.Play();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = SpawnPosition;
        

        //do respawn thing
    }
}
