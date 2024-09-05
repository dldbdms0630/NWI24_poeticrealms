using UnityEngine;

public class Deathtouch : MonoBehaviour
{
    private bool touchEnabled = false; // Toggle for enabling/disabling disappearance

    private void OnCollisionEnter(Collision collision)
    {
        if (touchEnabled && collision.gameObject.CompareTag("PlayerHand"))
        {
            // Make the object disappear (destroy the object)
            Destroy(gameObject);
        }
    }

    // Optional: If you want to use triggers instead of collisions
    private void OnTriggerEnter(Collider other)
    {
        if (touchEnabled && other.CompareTag("PlayerHand"))
        {
            // Make the object disappear (destroy the object)
            Destroy(gameObject);
        }
    }

    // Public method to enable disappearance
    public void Enable()
    {
        touchEnabled = true;
    }

    // Public method to disable disappearance
    public void Disable()
    {
        touchEnabled = false;
    }
}