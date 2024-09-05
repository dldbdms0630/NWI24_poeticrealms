using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class TriggerPoem : MonoBehaviour
{
    public class PoemManager : MonoBehaviour
    {
        // Static instance to keep track globally
        public static bool isPoemActive = false;

        // Call this when a new poem starts
        public static void StartPoem() {
            isPoemActive = true;
        }

        // Call this when the current poem finishes
        public static void EndPoem() {
            isPoemActive = false;
        }
    }

    public GameObject basePoem;
    private TextMeshPro poemText;

    public GameObject[] lines; 
    private TextMeshPro lineText;    
    private string lineStr;

    public NurtObjManager nurtObjManager;
    public FSObjManager fsObjManager;

    private AudioSource audioSource; 
    private InputData inputData;
    private string sceneName;
    private GameObject obj;
    

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
            if (!isStanzaDone && Abutton && !audioSource.isPlaying && canAdvanceText) {
                StartCoroutine(ChangeText());
            }
        }
    }

    IEnumerator HandleInitialText() {
        string initialText = NormalizeText(poemText.text);
        yield return new WaitForSeconds(audioSource.clip.length);
        // isStanzaDone = false; 


        if (sceneName == "Nurturers") {
            if (initialText == "Let 'em hear the hymns of your searching-fearless eyes,") 
                nurtObjManager.EnablePolaroidTwo();

            // else if (initialText == "Know")
            //     nurtObjManager.EnableWindowVideo();

            else if (initialText == "I wonder—")
                nurtObjManager.EnableParticles();

            else if (initialText == "I wonder—you consoled me")
                // canAdvanceText = false;
                nurtObjManager.StartCoroutine(nurtObjManager.EnableComputerEvent());
        }
        else if (sceneName == "Freespirits") {
            if (initialText == "I wonder—you consoled me")
                fsObjManager.StartCoroutine(fsObjManager.EnableComputerEvent());
        }

    }

    IEnumerator ChangeText() {
        canAdvanceText = false;

        if (idx < lines.Length) {
            audioSource = lines[idx].GetComponent<AudioSource>();
            lines[idx].SetActive(true);
            
            lineText = lines[idx].GetComponent<TextMeshPro>();
            lineStr = NormalizeText(lineText.text);
            

            yield return new WaitForSeconds(audioSource.clip.length);

            if (sceneName == "Nurturers") {
                if (lineStr == "We ran away from robots—those brainsick bots—") 
                    // nurtObjManager.PrepareTV();
                    nurtObjManager.EnableTV();
                
                else if (lineStr == "my mistake.") {
                    yield return new WaitForSeconds(1);
                    nurtObjManager.EnablePolaroidOne();
                }

                else if (lineStr == "your seashells-don't-rust eyes.") {
                    yield return new WaitForSeconds(1);
                    nurtObjManager.EnableWindowPortal();
                }

                // else if (lineStr == "I digested every moving moment you contained me in them,")
                //     nurtObjManager.EnableWindowVideo();

                else if (lineStr == "with raw faith, with silent love—") {
                    yield return new WaitForSeconds(1);
                    nurtObjManager.EnableHandPortal();
                }

                else if (lineStr == "like frantic wishes at 11:11,") {
                    nurtObjManager.PlayClockSound();
                }
                else if (lineStr == "hand in hand—we're running hand in hand—")
                    nurtObjManager.EnableHandMovie();

                else if (lineStr == "your breath is certain & we keep running.") {
                    yield return new WaitForSeconds(1);
                    nurtObjManager.EnableFirstWonder();
                }

                else if (lineStr == "why do I hold you like you will slip away?") {
                    yield return new WaitForSeconds(1);
                    nurtObjManager.EnableComputerPortal();
                }

                else if (lineStr == "where have you gone to?") {
                    yield return new WaitForSeconds(1);
                    nurtObjManager.EnableSecondToLast();
                }
                else if (lineStr == "So I surrender,")
                    nurtObjManager.EnableSmileyStanza();

                 else if (lineStr == "like I-see-you-in-every-single-smiley—") {
                    yield return new WaitForSeconds(3);
                    nurtObjManager.StartCoroutine(nurtObjManager.GoToLastStanza());
                }




            } else if (sceneName == "Freespirits") {
                if (lineStr == "ddddmy mistake.") {
                    yield return new WaitForSeconds(1);
                    fsObjManager.MoveButterflyToDisco(); 
                }
                else if (lineStr == "my mistake.")
                {
                    yield return new WaitForSeconds(1);
                    fsObjManager.MoveToSecondStump();
                }
                else if (lineStr == "your seashells-don't-rust eyes.") {
                    yield return new WaitForSeconds(1);
                    fsObjManager.MoveButterflyToWishingWell();
                }
                else if (lineStr == "with raw faith, with silent love—") {
                    yield return new WaitForSeconds(1);
                    fsObjManager.MoveButterflyToStreetLight();
                }
                else if (lineStr == "hand in hand—we're running hand in hand—")
                {
                    fsObjManager.TurnStreetLightOn();
                }
                else if (lineStr == "your breath is certain & we keep running.") {
                    yield return new WaitForSeconds(1);
                    fsObjManager.MoveButterflyToMailBox();
                }
                else if (lineStr == "why do I hold you like you will slip away?") {
                    fsObjManager.EnableHandTrail();
                    yield return new WaitForSeconds(1); 
                    fsObjManager.MoveButterflyToComp();
                }
                else if (lineStr == "where have you gone to?")
                {
                    fsObjManager.DisableHandTrail();
                    yield return new WaitForSeconds(1);
                    fsObjManager.MoveButterflyToMirror();
                }
                else if (lineStr == "like I-see-you-in-every-single-smiley—") {
                    fsObjManager.EnableDoor();
                    yield return new WaitForSeconds(2);
                    fsObjManager.FinalDoor();
                }

            }
            idx++;
        } else {
            isStanzaDone = true;
            PoemManager.EndPoem();
            isFirstTrigger = true;
        }
        yield return new WaitForSeconds(0.5f); // Debounce delay
        PoemManager.EndPoem();

        canAdvanceText = true; // Allow next trigger
    }



    private void OnTriggerEnter(Collider collision) {
        Debug.Log("Triggered by: " + collision.gameObject.name);

        if (collision.gameObject.tag == "MainCamera" && isFirstTrigger) {
            if (PoemManager.isPoemActive) {
                Debug.Log("Poem already active .");

                return; // Do nothing if a poem is already active
            }

            Debug.Log("Starting new poem...");

            isFirstTrigger = false; // to prevent multiple triggers 

            PoemManager.StartPoem();


            basePoem.SetActive(true); // when basePoem is enabled, the animation will play, as well as the poem associated with it

            StartCoroutine(HandleInitialText());


            if (obj.name == "tv collide")
                nurtObjManager.DisableTitle();
            
            if (obj.name == "pola collide") {
                nurtObjManager.EnablePolaroidTwo();
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

}
