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
    public bool canAdvanceText = true;
    private string sceneName;


    private void Start()
    {
        inputData = GetComponent<InputData>();
        audioSource = GetComponent<AudioSource>();
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (isGazed && canAdvanceText && inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton))
        {
            if (!isStanzaDone && Abutton && !audioSource.isPlaying)
            // ChangeText();
            StartCoroutine(ChangeText());
        }
    }

    // void ChangeText()
    // {
    //     if (textIdx < newTexts.Length) {
    //         textObject.text = newTexts[textIdx];
    //         audioSource.clip = audioClips[textIdx];
    //         audioSource.Play();

    //         if (sceneName == "Nurturers") {
    //             if (newTexts[textIdx] == "Dreamed of you last night.")
    //                 nurtObjManager.DisableTitle();
                
    //             else if (newTexts[textIdx] == "We ran away from robots—those brainsick bots—") 
    //                 nurtObjManager.EnableTV();
                
                
    //         }
    //         textIdx++;
    //     }
    //     else isStanzaDone = true;
    // }

    IEnumerator ChangeText()
    {
        if (textIdx < newTexts.Length) {
            textObject.text = newTexts[textIdx];
            audioSource.clip = audioClips[textIdx];
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);


            if (sceneName == "Nurturers") {
                if (newTexts[textIdx] == "Dreamed of you last night.")
                    nurtObjManager.DisableTitle();
                
                else if (newTexts[textIdx] == "We ran away from robots—those brainsick bots—") 
                    nurtObjManager.EnableTV();
                
                else if (newTexts[textIdx] == "my mistake.") {
                    yield return new WaitForSeconds(1);
                    nurtObjManager.EnablePolaroidOne();
                }
                else if (newTexts[textIdx] == "Let 'em hear the hymns of your searching-fearless eyes,") 
                    nurtObjManager.EnablePolaroidTwo();

                else if (newTexts[textIdx] == "your seashells-don't-rust eyes.") {
                    yield return new WaitForSeconds(1);
                    nurtObjManager.EnableWindowPortal();
                }

                else if (newTexts[textIdx] == "Know")
                    nurtObjManager.EnableWindowVideo();

                else if (newTexts[textIdx] == "with raw faith, with silent love—") {
                    yield return new WaitForSeconds(1);
                    nurtObjManager.EnableHandPortal();
                }

                else if (newTexts[textIdx] == "notice: We're still running")
                    nurtObjManager.EnableHandMovie();

                else if (newTexts[textIdx] == "your breath is certain & we keep running.") {
                    yield return new WaitForSeconds(1);
                    nurtObjManager.EnableFirstWonder();
                }
                
                else if (newTexts[textIdx] == "I wonder—")
                    // nurtObjManager.EnableParticles();

                else if (newTexts[textIdx] == "why do I hold you like you will slip away?") {
                    yield return new WaitForSeconds(1);
                    nurtObjManager.EnableComputerPortal();
                }


                else if (newTexts[textIdx] == "I wonder—you consoled me")
                    // canAdvanceText = false;
                    nurtObjManager.EnableComputerEvent();
                

                else if (newTexts[textIdx] == "where have you gone to?") {
                    yield return new WaitForSeconds(1);
                    nurtObjManager.EnableSecondToLast();
                }


                else if (newTexts[textIdx] == "So I surrender,")
                    nurtObjManager.EnableSmileyStanza();

                 else if (newTexts[textIdx] == "like I-see-you-in-every-single-smiley—") {
                    yield return new WaitForSeconds(3);
                    nurtObjManager.GoToLastStanza();
                }

            } else if (sceneName == "NoFunNurt") {
                if (newTexts[textIdx] == "it's all you.")  {
                    yield return new WaitForSeconds(1);
                    nurtObjManager.FadeBgMusic();

                }                  

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