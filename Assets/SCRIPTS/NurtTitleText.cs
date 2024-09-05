using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.SceneManagement;


public class NurtTitleText : MonoBehaviour
{
    // public GameObject title;
    public GameObject pressAToAdvance;
    public GameObject butterfly; 
    public GameObject portal; 
    // public GameObject testCube;

    public GameObject audioObj;
    // private AudioSource bgAudio; 
    private InputData inputData;
    private Animation anim;
    private string sceneName;
    private bool firstTrigger = true; 


    // Start is called before the first frame update
    void Start()
    {
        inputData = GetComponent<InputData>();
        // bgAudio = audioObj.GetComponent<AudioSource>();
        StartCoroutine(WaitSeconds());
        sceneName = SceneManager.GetActiveScene().name;
        anim = butterfly.GetComponent<Animation>();

    }

    IEnumerator WaitSeconds() {
        yield return new WaitForSeconds(3);
        audioObj.SetActive(true);
        pressAToAdvance.SetActive(true);
    }

    void Update()
    {  // don't put gaze here cuz we don't necessarily need it for the title 
        if (inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton)) 
        {
            // if (Abutton && ) { sceneName is freespirits butterfly.setactive(true) but if not 
            //     butterfly.SetActive(true); // then butterfly will appear with default animation 
            // }
            if (Abutton && sceneName == "Nurturers") {
                portal.SetActive(true);
            } else if (Abutton && firstTrigger && sceneName == "Freespirits") {
                // testCube.SetActive(true);
                anim.Play("beginning to first stump");
                firstTrigger = false; 
            }
           
        }
    }
}
