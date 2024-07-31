using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBlockMover : MonoBehaviour
{
    //public float minSpinSpeed;
    public float maxSpinSpeed;
    private float spinSpeedX, spinSpeedY, spinSpeedZ;

    void Start()
    {
        spinSpeedX = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        spinSpeedY = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        spinSpeedZ = Random.Range(-maxSpinSpeed, maxSpinSpeed);
    }

    void Update()  // continuously spin 
    {

        // make them spin in one direction, randomly between two public values
        // spin to the left 
        //transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(spinSpeedX, spinSpeedY, spinSpeedZ) * Time.deltaTime);

    }
}
