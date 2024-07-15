using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinRandomly : MonoBehaviour
{
    public float minSpinSpeed = 6f;
    public float maxSpinSpeed = 16f;
    private float spinSpeed;


    void Start()
    {
        spinSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
    }

    void Update()  // continusly spin 
    {
        if (gameObject.CompareTag("discoball"))
        {
            // make them spin in one direction, randomly between two public values
            // spin to the left 
            transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
        }
        else if (gameObject.CompareTag("discoball2")) 
        {
            // spin to the right
            transform.Rotate(Vector3.back, spinSpeed * Time.deltaTime);

        }
    }
}

//     void Update()  // continuously spin 
//     {
//         if (gameObject.CompareTag("discoball"))
//         {
//             // Spin to the left
//             transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
//         } 
//         else if (gameObject.CompareTag("discoball2")) 
//         {
//             // Spin to the right
//             transform.Rotate(Vector3.back, spinSpeed * Time.deltaTime);
//         }
//     }
// }


//         // Choose a random spin speed between the minimum and maximum values
//         spinSpeed = Random.Range(minSpinSpeed, maxSpinSpeed);
//     }

//     void Update()  // continuously spin 
//     {
//         if (gameObject.CompareTag("discoball"))
//         {
//             // Spin in one direction
//             transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
//         } 
//         else if (gameObject.CompareTag("discoball2")) 
//         {
//             // Spin in the other direction
//             transform.Rotate(Vector3.down, spinSpeed * Time.deltaTime);
//         }
//     }
// }
