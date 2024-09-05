using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class PortalActivator : MonoBehaviour
{
    public GameObject basePoem;
    public GameObject[] lines;
    private TextMeshPro lineText;    
        private int idx = 0;


    private int sceneNum;
    //public Animator fadeAnimator;
    public QuizActivator quizActivator;
    public GameObject fadescreen;
    public GameObject fadenum2;
    private string sceneName;
    public AudioSource bgMusic;
    private bool isGazed = false, canAdvanceText = true;

    // public GameObject firstLine;
    private InputData inputData;
    private AudioSource audioSource; 


    void Update()
    {
        if (isGazed && inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton)) {
            if (Abutton && !audioSource.isPlaying && canAdvanceText) {
                StartCoroutine(ChangeText());
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = basePoem.GetComponent<AudioSource>();

        sceneNum = -1;
        fadescreen.SetActive(false);
        sceneName = SceneManager.GetActiveScene().name;
        fadenum2.SetActive(false);
        inputData = GetComponent<InputData>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")|| other.CompareTag("MainCamera"))
        {
            Debug.Log("Interacted!!");
            if (sceneName == "Freespirits") {
                StartCoroutine(FadeForFreeSpiritsDemo());
            } else
                StartCoroutine(LoadPoemScene());
        }
    }

// new brick solution for demo day yooeun 
    IEnumerator FadeForFreeSpiritsDemo() {
        StartCoroutine(FadeAudioSource.StartFade(bgMusic, 3, 0));

        fadescreen.SetActive(true);
        yield return new WaitForSeconds(3);
        fadenum2.SetActive(true);
        yield return new WaitForSeconds(1);

        basePoem.SetActive(true);

    }

    IEnumerator ChangeText() {
        canAdvanceText = false;

        if (idx < lines.Length) {
            audioSource = lines[idx].GetComponent<AudioSource>();
            lines[idx].SetActive(true);
            
            lineText = lines[idx].GetComponent<TextMeshPro>();
            
            yield return new WaitForSeconds(audioSource.clip.length);

            if (lineText.text == "Alone, I whisper,") {
                yield return new WaitForSeconds(1);
            } else if (lineText.text == "it's all your fault.") {
                 yield return new WaitForSeconds(1);
            } else if (lineText.text == "No, scratch that—") {
                yield return new WaitForSeconds(1);
            }
            // } else if (lineText.text == "it's all you.") {
            
            //     // FadeBgMusic();
            // }
            idx++;
        }
        yield return new WaitForSeconds(0.5f); // Debounce delay

        canAdvanceText = true; // Allow next trigger
    }

    private IEnumerator LoadPoemScene()
    {
        //fadeAnimator.SetTrigger("FadeOut");
        fadescreen.SetActive(true);

        sceneNum = quizActivator.getScene();

        yield return new WaitForSeconds(2);

        if (sceneNum == 1)
        {
            Debug.Log("fs load");
            SceneManager.LoadScene("Freespirits");
        }
        else if (sceneNum == 2)
        {
            Debug.Log("nurt load");
            SceneManager.LoadScene("Nurturers");
        }
        else if (sceneNum == 3)
        {
            Debug.Log("vis load");
            //SceneManager.LoadScene("Nurturers");

            SceneManager.LoadScene("Visionaries");
        }
        else
        {
            Debug.Log("something went wrong homie, heres scenenum: " + sceneNum);
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
}
