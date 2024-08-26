using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starlaunch : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    private Rigidbody rb1;
    private Rigidbody rb2;

    //do sounds? 
    
    // Start is called before the first frame update
    void Start()
    {
        rb1 = star1.GetComponent<Rigidbody>();
        rb2 = star2.GetComponent<Rigidbody>();
        rb1.useGravity = false; rb2.useGravity = false;

        star1.SetActive(false);
        star2.SetActive(false);

        //triggerStars();
    }

    public void triggerStars()
    {
        star1.SetActive(true);
        star2.SetActive(true);

        //reset stuff
        rb1.useGravity = true; rb2.useGravity = true;
        rb1.velocity = Vector3.zero; rb2.velocity = Vector3.zero;
        rb1.angularVelocity = Vector3.zero; rb2 .velocity = Vector3.zero;

        Vector3 force = new Vector3(-500, -20, -10);
        rb1.AddForce(force);
        rb2.AddForce(force);
    }

}
