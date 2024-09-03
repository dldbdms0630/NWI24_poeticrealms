using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SlapInteractable : MonoBehaviour
{
    public float slapForce = 2f;
    public XRBaseController controllerL; 
    public XRBaseController controllerR; 

    public float hapticDuration = 0.1f;
    public float hapticIntensity = 0.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerHand"))
        {
            // Apply force in the direction of the collision
            Vector3 forceDirection = collision.contacts[0].normal * -1;
            rb.AddForce(forceDirection * slapForce, ForceMode.Impulse);

            // Determine which controller caused the collision
            XRBaseController triggeringController = GetControllerFromCollision(collision);
            if (triggeringController != null)
            {
                // Provide haptic feedback to the specific controller
                triggeringController.SendHapticImpulse(hapticIntensity, hapticDuration);
            }
        }
    }

    private XRBaseController GetControllerFromCollision(Collision collision)
    {
        // Check if the collided object has a controller tag or specific component
        // Assuming the hands are tagged as "PlayerHandL" for the left hand and "PlayerHandR" for the right hand
        if (collision.gameObject.name.Contains("Left"))
        {
            return controllerL;
        }
        else if (collision.gameObject.name.Contains("Right"))
        {
            return controllerR;
        }

        // If no match is found, return null
        return null;
    }
}