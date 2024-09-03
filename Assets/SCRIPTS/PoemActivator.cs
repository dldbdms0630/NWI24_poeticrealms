using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectActivator : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public float activationDistance = 3.0f;
    public float spawnDistance = 1.0f;
    public float activationInterval = 30.0f;
    public float travelDistance = 5.0f;
    public LayerMask terrainLayer;

    private Vector3 startingPosition;
    private Vector3 lastActivationPosition;
    private float timer;
    private int currentIndex = 0;

    // Dictionary to store height adjustments for different objects
    private Dictionary<GameObject, float> heightAdjustments = new Dictionary<GameObject, float>();

    void Start()
    {
        startingPosition = transform.position;
        lastActivationPosition = startingPosition;
        timer = 0.0f;

        // Initialize height adjustments (example values)
        foreach (var obj in objectsToActivate)
        {
            heightAdjustments[obj] = 1.0f; // Adjust this value as needed
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= activationInterval && Vector3.Distance(startingPosition, transform.position) >= activationDistance)
        {
            if (currentIndex < objectsToActivate.Length && Vector3.Distance(lastActivationPosition, transform.position) >= travelDistance)
            {
                Vector3 spawnPosition = transform.position + transform.forward * spawnDistance;

                // Use Raycast to find the correct height above the terrain
                if (Physics.Raycast(spawnPosition + Vector3.up * 10, Vector3.down, out RaycastHit hit, Mathf.Infinity, terrainLayer))
                {
                    spawnPosition.y = hit.point.y + heightAdjustments[objectsToActivate[currentIndex]];
                }

                objectsToActivate[currentIndex].transform.position = spawnPosition;
                objectsToActivate[currentIndex].SetActive(true);
                lastActivationPosition = transform.position;
                currentIndex++;
                timer = 0.0f;
            }
        }
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// using UnityEngine;

// public class PoemActivator : MonoBehaviour
// {
//     public GameObject[] objectsToActivate;
//     public float activationDistance = 3.0f;
//     public float spawnDistance = 3.0f;
//     public float activationInterval = 30.0f;
//     public float travelDistance = 10.0f;

//     private Vector3 startingPosition;
//     private Vector3 lastActivationPosition;
//     private float timer;
//     private int currentIndex = 0;

//     void Start()
//     {
//         startingPosition = transform.position;
//         lastActivationPosition = startingPosition;
//         timer = 0.0f;
//     }

//     void Update()
//     {
//         timer += Time.deltaTime;

//         if (timer >= 10.0f && Vector3.Distance(startingPosition, transform.position) >= activationDistance)
//         {
//             Debug.Log("Start activation!!!!"); 
//             if (currentIndex < objectsToActivate.Length && Vector3.Distance(lastActivationPosition, transform.position) >= travelDistance)
//             {
//                 Vector3 spawnPosition = transform.position + transform.forward * spawnDistance;
//                 objectsToActivate[currentIndex].transform.position = spawnPosition;
//                 objectsToActivate[currentIndex].SetActive(true);
//                 lastActivationPosition = transform.position;
//                 currentIndex++;
//                 timer = 0.0f;
//             }
//         }
//     }
// }

