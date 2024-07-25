using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.SceneManagement;
using TMPro;


/* Changes text when the primary button is pressed. Ideally, would work with Gaze Interactor.
 * After that is done, then will implement sound associated with text as well. 
 */
public class ChangeTextOnTrigger : MonoBehaviour
{
    public TextMeshPro textObject;
    // public TextMeshPro signalText; // for the "Press A to advance" message when player doesn't do anything for 3sec after the audio stops 

    public string[] newTexts = {"New Text A", "New Text B", "New Text C", "New Text D"};
    public AudioClip[] audioClips; // Array of audio clips
    public NurtObjManager nurtObjManager;

    private AudioSource audioSource; // Audio source to play the clips
    private int textIdx = 0;

    private InputData inputData;
    private bool isStanzaDone = false, isGazed = false;
    private string sceneName;


    private void Start()
    {
        inputData = GetComponent<InputData>();
        audioSource = GetComponent<AudioSource>();
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (isGazed && inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton))
        {
            if (!isStanzaDone && Abutton && !audioSource.isPlaying)
            ChangeText();
        }
    }

    void ChangeText()
    {
        if (textIdx < newTexts.Length) {
            textObject.text = newTexts[textIdx];
            audioSource.clip = audioClips[textIdx];
            audioSource.Play();

            if (sceneName == "Nurturers") {
                if (newTexts[textIdx] == "Dreamed of you last night.")
                    nurtObjManager.DisableTitle();
                
                else if (newTexts[textIdx] == "We ran away from robots—those brainsick bots—") 
                    nurtObjManager.EnableTV();
                
            }
            textIdx++;
        }
        else isStanzaDone = true;
    }


    public void EnableGaze() 
    {
        isGazed = true;
    }

    public void DisableGaze() 
    {
        isGazed = false;
    }
}