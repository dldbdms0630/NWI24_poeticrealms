using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggersScript : MonoBehaviour
{
    private bool selected;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("testing triggeres ");
        selected = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!selected)
        {
            if (other.CompareTag("OptionA"))
            {
                Debug.Log("option A!!");
                selected = true;
            }
            else if (other.CompareTag("OptionB"))
            {
                Debug.Log("option B!!");
                selected = true;
            }
            else if (other.CompareTag("OptionC"))
            {
                Debug.Log("option C!!");
                selected = true;
            }
            else if (other.CompareTag("OptionBack"))
            {
                Debug.Log("Back!!");
                selected = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (selected)
        {
            selected = false; 
        }
    }
}
