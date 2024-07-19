using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingSphere : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerHand"))
        {
            Debug.Log("COLLISION DETECT");
            // Apply a force when colliding with the player's hand
            Vector3 forceDirection = collision.contacts[0].point - transform.position;
            forceDirection = -forceDirection.normalized;
            rb.AddForce(forceDirection * 10, ForceMode.Impulse);
        }
    }
}
