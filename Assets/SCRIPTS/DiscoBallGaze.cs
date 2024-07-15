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
    private float floatStrength = 0.3f; // how high the object goes. rn +- 1 

    void Start() 
    {
        this.originalY = this.transform.position.y;
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
    }

    public void StopBobbing() {
        StartCoroutine(GradualSlowdown());
    }

    IEnumerator GradualSlowdown()
    {
        while (floatStrength > 0)
        {
            floatStrength -= Time.deltaTime;
            yield return null;
        }
        isMoving = false;
        floatStrength = 1; // set back to default param
    }
}
