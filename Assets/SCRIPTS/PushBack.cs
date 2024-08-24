using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBack : MonoBehaviour
{
    public float pushBackForce = 10f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            Vector3 pushDirection = transform.position - collision.transform.position;
            pushDirection.y = 0; // Keep the push direction horizontal
            GetComponent<Rigidbody>().AddForce(pushDirection.normalized * pushBackForce, ForceMode.Impulse);
        }
    }
}
