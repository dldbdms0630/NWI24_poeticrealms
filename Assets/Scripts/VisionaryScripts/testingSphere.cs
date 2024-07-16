using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingSphere : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject homieSphere;

    void Start()
    {
        homieSphere.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
