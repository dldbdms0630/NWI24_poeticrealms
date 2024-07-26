using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class NurtTitleText : MonoBehaviour
{
    public GameObject title;
    public GameObject pressAToAdvance;

    private AudioSource bgAudio; 
    private InputData inputData;

    // Start is called before the first frame update
    void Start()
    {
        inputData = GetComponent<InputData>();
        bgAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {  
        if (inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton)) 
        {

        }
    }
}
