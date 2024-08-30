using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollower : MonoBehaviour
{
    public Transform vrCamera; // Assign the VR camera here
    public Vector3 offset = new Vector3(0, -0.3f, 1f); // Offset from the camera

    void Update()
    {
        // Make the subtitle canvas follow the camera with an offset
        transform.position = vrCamera.position + vrCamera.forward * offset.z + vrCamera.up * offset.y + vrCamera.right * offset.x;
        transform.LookAt(vrCamera.position + vrCamera.forward * 10); // Make it always face the user
    }
}
