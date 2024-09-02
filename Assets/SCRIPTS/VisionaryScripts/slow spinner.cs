using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowspinner : MonoBehaviour
{

    [Header("Rotation Settings")]
    public float rotationSpeedY = 1f; // Degrees per second
    public float rotationSpeedX = 0f; // Degrees per second
    public float rotationSpeedZ = 0f; // Degrees per second

    [Header("Oscillation Settings")]
    public float amplitude = 0.01f;     // Maximum height from the starting point
    public float frequency = 0.1f;       // Oscillation cycles per second

    // Starting position of the object
    private Vector3 startPosition;

    void Start()
    {
        // Record the starting position
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate the object around its Y-axis
        RotateObject();

        // Oscillate the object up and down
        OscillateObject();
    }

    void RotateObject()
    {
        transform.Rotate(rotationSpeedX * Time.deltaTime, rotationSpeedY * Time.deltaTime, rotationSpeedZ * Time.deltaTime);
    }

    void OscillateObject()
    {
        // Calculate the new Y position
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency * Mathf.PI * 2) * amplitude;

        // Apply the new position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
