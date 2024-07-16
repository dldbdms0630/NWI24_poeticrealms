using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script is called / triggered when activated by Gaze Interactor. 
 * Disco balls will start spinning when activated. 
 */ 

public class DiscoBallGaze : MonoBehaviour
{
    private bool isMoving = false; 
    private float originalY; 
    private float floatStrength = 0.1f; // how high the object goes. rn +- 1 
    private AudioSource chimeSound; 

    void Start() 
    {
        this.originalY = this.transform.position.y;
        chimeSound = GetComponent<AudioSource>();

    }

    void Update() 
    {
        if (isMoving) 
        {
            transform.position = new Vector3(transform.position.x, 
                originalY + ((float)Mathf.Sin(Time.time) * floatStrength), 
                transform.position.z);
        }
    }

    public void StartBobbing() 
    {
        isMoving = true;
        chimeSound.Play();
    }

    public void StopBobbing() {
        // StartCoroutine(GradualSlowdown());
        transform.position = new Vector3(transform.position.x, originalY, transform.position.z);
        isMoving = false;
    }

    // IEnumerator GradualSlowdown()
    // {
    //     while (floatStrength > 0)
    //     {
    //         floatStrength -= Time.deltaTime;
    //         yield return null;
    //     }
    //     isMoving = false;
    //     floatStrength = 1; // set back to default param
    // }
}
