using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class TriggerPoem : MonoBehaviour
{
    public GameObject basePoem;
    private TextMeshPro poemText;

    public GameObject[] lines; 
    private TextMeshPro lineText;    
    private string lineStr;


    public NurtObjManager nurtObjManager;

    private AudioSource audioSource; 
    private InputData inputData;
    private string sceneName;
    private GameObject obj;
    
    // isGazed determines whether gaze raycast is colliding with text collider or not
    // isStanzaDone is in place - WHY? what's the reason? 
    // isFirstTrigger makes sure that the OnTrigger method is not triggered multiple times. 
    // canAdvanceText - WHY???? 
    private bool isGazed = false, isStanzaDone = false, isFirstTrigger = true, canAdvanceText = true;
    private int idx = 0;

    void Start() {
        inputData = GetComponent<InputData>();
        poemText = basePoem.GetComponent<TextMeshPro>();
        audioSource = basePoem.GetComponent<AudioSource>(); 
        sceneName = SceneManager.GetActiveScene().name;
        obj = this.gameObject;


    }

    void Update()
    {
        if (isGazed && inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton)) {
            if (!isStanzaDone && Abutton && !audioSource.isPlaying) {
                ChangeText();
            }
        }
    }

    void ChangeText() {
        if (idx < lines.Length) {
            audioSource = lines[idx].GetComponent<AudioSource>();
            lines[idx].SetActive(true);
            
            lineText = lines[idx].GetComponent<TextMeshPro>();
            lineStr = NormalizeText(lineText.text);


            if (sceneName == "Nurturers") {
                // if (lineStr == "Dreamed of you last night.")
                //     nurtObjManager.DisableTitle();
                
                if (lineStr == "We ran away from robots—those brainsick bots—") 
                    nurtObjManager.EnableTV();
                
                else if (lineStr == "my mistake.") {
                    // yield return new WaitForSeconds(1);
                    nurtObjManager.EnablePolaroidOne();
                }
                else if (lineStr == "Let 'em hear the hymns of your searching-fearless eyes,") 
                    nurtObjManager.EnablePolaroidTwo();

                else if (lineStr == "your seashells-don't-rust eyes.") {
                    // yield return new WaitForSeconds(1);
                    nurtObjManager.EnableWindowPortal();
                }

                else if (lineStr == "Know")
                    nurtObjManager.EnableWindowVideo();

                else if (lineStr == "with raw faith, with silent love—") {
                    // yield return new WaitForSeconds(1);
                    nurtObjManager.EnableHandPortal();
                }

                else if (lineStr == "notice: We're still running")
                    nurtObjManager.EnableHandMovie();

                else if (lineStr == "your breath is certain & we keep running.") {
                    // yield return new WaitForSeconds(1);
                    nurtObjManager.EnableFirstWonder();
                }
                
                else if (lineStr == "I wonder—")
                    nurtObjManager.EnableParticles();

                else if (lineStr == "why do I hold you like you will slip away?") {
                    // yield return new WaitForSeconds(1);
                    nurtObjManager.EnableComputerPortal();
                }


                else if (lineStr == "I wonder—you consoled me")
                    // canAdvanceText = false;
                    nurtObjManager.EnableComputerEvent();
                

                else if (lineStr == "where have you gone to?") {
                    // yield return new WaitForSeconds(1);
                    nurtObjManager.EnableSecondToLast();
                }


                else if (lineStr == "So I surrender,")
                    nurtObjManager.EnableSmileyStanza();

                 else if (lineStr == "like I-see-you-in-every-single-smiley—") {
                    // yield return new WaitForSeconds(3);
                    nurtObjManager.GoToLastStanza();
                }

            } else if (sceneName == "NoFunNurt") {
                if (lineStr == "it's all you.")  {
                    // yield return new WaitForSeconds(1);
                    nurtObjManager.FadeBgMusic();

                }
            }

            idx++;
        } else isStanzaDone = true;
    }



    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "PlayerBody" && isFirstTrigger) {
            isFirstTrigger = false; // to prevent multiple triggers 
            // poemText.text = lines[0];
            // audioSource.clip = audioClips[idx];

            basePoem.SetActive(true); // when basePoem is enabled, the animation will play, as well as the poem associated with it

            if (obj.name == "tv collide") {
                nurtObjManager.DisableTitle();
            }
        }
    }

    public void EnableGaze() 
    {
        isGazed = true;
    }

    public void DisableGaze() 
    {
        isGazed = false;
    }

    string NormalizeText(string text) {
        // Trim leading and trailing spaces
        text = text.Trim();
        // Replace line breaks with spaces
        text = text.Replace("\n", " ").Replace("\r", " ");
        // Remove extra spaces
        text = System.Text.RegularExpressions.Regex.Replace(text, @"\s+", " ");
        return text;
}

    // void Update()
    // {
    //     if (isGazed && canAdvanceText && inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton))
    //     {
    //         if (!isStanzaDone && Abutton && !audioSource.isPlaying) {}
    //         // StartCoroutine(ChangeText());
    //     }
    // }

    // IEnumerator ChangeText()
    // {
    //     if (idx < lines.Length) {
    //         textObject.text = lineText;
    //         audioSource.clip = audioClips[idx];
    //         audioSource.Play();
    //         yield return new WaitForSeconds(audioSource.clip.length);


    // private void OnTriggerEnter(Collider collision) {
    //     if (collision.gameObject.tag == "PlayerBody" && isFirstTrigger) {
    //         isFirstTrigger = false; // to prevent multiple triggers 
    //         poemText.text = lines[0];
    //         audioSource.clip = audioClips[idx];

    //         basePoem.SetActive(true);
    //         audioSource.Play(); // play sound as poem is enabled?
    //     }
    // }

}
