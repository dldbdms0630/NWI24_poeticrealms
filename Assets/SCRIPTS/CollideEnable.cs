using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideEnable : MonoBehaviour
{
    public GameObject particleSystem;
    

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "MainCamera") 
            particleSystem.SetActive(true);
    }
}
