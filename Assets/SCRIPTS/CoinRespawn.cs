using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRespawn : MonoBehaviour
{
    /*public Transform respawnPoint; // Point where the coin will respawn
    public float respawnHeightThreshold = -10f; // Height threshold for respawning

    private CoinGrab coinGrabber;

    void Start()
    {
        coinGrabber = GetComponent<CoinGrab>();
    }

    void Update()
    {
        // Check if the coin is below the respawn height threshold
        if (transform.position.y < respawnHeightThreshold)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Reset the coin's position to the respawn point
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        // Reset other necessary states if needed
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        // Re-enable the collider in case it was disabled during grabbing
        Collider coinCollider = GetComponent<Collider>();
        if (coinCollider != null)
        {
            coinCollider.enabled = true;
        }

        Debug.Log("Coin respawned!");
    }
    */
}
