using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class NurtTitleText : MonoBehaviour
{
    // public GameObject title;
    public GameObject pressAToAdvance;
    public GameObject firstSignal;
    public GameObject colliderObj;

    public GameObject audioObj;
    // private AudioSource bgAudio; 
    private InputData inputData;

    // Start is called before the first frame update
    void Start()
    {
        inputData = GetComponent<InputData>();
        // bgAudio = audioObj.GetComponent<AudioSource>();
        StartCoroutine(WaitSeconds());
    }

    IEnumerator WaitSeconds() {
        yield return new WaitForSeconds(3);
        pressAToAdvance.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {  // don't put gaze here cuz we don't necessarily need it for the title 
        if (inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton)) 
        {
            if (Abutton) {
                audioObj.SetActive(true);
                firstSignal.SetActive(true); 
                colliderObj.SetActive(true); // make sure collider only enabled after title 
            }
           
        }
    }
}
