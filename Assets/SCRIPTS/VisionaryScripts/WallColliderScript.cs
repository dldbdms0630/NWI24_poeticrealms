using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColliderScript : MonoBehaviour
{
    public float bounceForce = 6f; // The force applied to bounce the object back towards the player
    public Transform playerTransform; // Reference to the player's transform
    public GameObject CUBETEST1;
    public GameObject CUBETEST2;

    private void OnCollisionEnter(Collision collision)
    {
        CUBETEST1.SetActive(true);
        
        // Check if the object that collided is the "clock"
        if (collision.gameObject.CompareTag("clock"))
        {
            // Get the Rigidbody of the clock
            Rigidbody clockRb = collision.gameObject.GetComponent<Rigidbody>();
            //CUBETEST2.SetActive(true);

            if (clockRb != null)
            {
                // Calculate the direction from the clock to the player
                Vector3 directionToPlayer = (playerTransform.position - collision.transform.position).normalized;

                // Apply a small force in the direction of the player
                clockRb.AddForce(directionToPlayer * bounceForce, ForceMode.Impulse);

                CUBETEST2.SetActive(true);
            }
        }


    }
}
