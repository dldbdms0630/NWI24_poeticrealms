using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class PoemActivator : MonoBehaviour
{
    public GameObject[] objectsToActivate;
    public float activationDistance = 3.0f;
    public float spawnDistance = 3.0f;
    public float activationInterval = 30.0f;
    public float travelDistance = 10.0f;

    private Vector3 startingPosition;
    private Vector3 lastActivationPosition;
    private float timer;
    private int currentIndex = 0;

    void Start()
    {
        startingPosition = transform.position;
        lastActivationPosition = startingPosition;
        timer = 0.0f;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 10.0f && Vector3.Distance(startingPosition, transform.position) >= activationDistance)
        {
            Debug.Log("Start activation!!!!"); 
            if (currentIndex < objectsToActivate.Length && Vector3.Distance(lastActivationPosition, transform.position) >= travelDistance)
            {
                Vector3 spawnPosition = transform.position + transform.forward * spawnDistance;
                objectsToActivate[currentIndex].transform.position = spawnPosition;
                objectsToActivate[currentIndex].SetActive(true);
                lastActivationPosition = transform.position;
                currentIndex++;
                timer = 0.0f;
            }
        }
    }
}

