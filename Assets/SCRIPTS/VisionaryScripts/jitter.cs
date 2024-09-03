using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jitter : MonoBehaviour
{
    public float jitterAmount = 0.005f;  // Maximum distance to jitter in any direction
    public float jitterDuration = 0.1f; // How long the jitter effect lasts
    public float minInterval = 1f;     // Minimum time between glitch activations
    public float maxInterval = 5f;     // Maximum time between glitch activations


    private Vector3 originalOffset;    // Offset from the current position, rather than a fixed point
    private Vector3 jitterPosition;
    private bool isJittering = false;

    void Start()
    {
        // Store the original position of the object
        //originalPosition = transform.position;

        // Start the glitch effect routine
        StartCoroutine(GlitchRoutine());
    }

    void Update()
    {
        if (isJittering)
        {
            // Calculate a random offset for each axis
            float offsetX = Random.Range(-jitterAmount, jitterAmount);
            float offsetY = Random.Range(-jitterAmount, jitterAmount);
            float offsetZ = Random.Range(-jitterAmount, jitterAmount);

            // Apply the random offset to the object's position
            jitterPosition = new Vector3(offsetX, offsetY, offsetZ);
            transform.position = transform.position + jitterPosition;
        }
    }

    IEnumerator GlitchRoutine()
    {
        while (true)
        {
            // Wait for a random interval before activating the glitch
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);

            // Capture the current position as the base for jittering
            originalOffset = transform.position;

            // Activate jitter
            isJittering = true;

            // Jitter for the specified duration
            yield return new WaitForSeconds(jitterDuration);

            // Stop jittering and return to the modified position
            isJittering = false;
            transform.position = originalOffset + jitterPosition;
        }
    }
}
