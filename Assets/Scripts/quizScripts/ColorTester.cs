using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTester : MonoBehaviour
{
    public ColorChanger changer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Set tint color to green when 'T' key is pressed
            changer.SetTintColor(Color.green);
        }
    }
}
