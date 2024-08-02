using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class NurtFinalStanza : MonoBehaviour
{
    public GameObject basePoem;
    public GameObject[] lines;
    private TextMeshPro lineText;    
    private string lineStr;
    private bool isGazed = false, canAdvanceText = true;
    private int idx = 0;

        // only for no fun nurt
    public AudioSource finalBgMusic;
    private AudioSource audioSource; 
    private InputData inputData;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitSeconds());
        inputData = GetComponent<InputData>();
        // poemText = basePoem.GetComponent<TextMeshPro>();
        audioSource = basePoem.GetComponent<AudioSource>();
    }

    IEnumerator WaitSeconds() {
        yield return new WaitForSeconds(5); // wait for fade screen to turn on
        
        basePoem.SetActive(true);
    }
    

    void Update()
    {
        if (isGazed && inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton)) {
            if (Abutton && !audioSource.isPlaying && canAdvanceText) {
                StartCoroutine(ChangeText());
            }
        }
    }

    IEnumerator ChangeText() {
        canAdvanceText = false;

        if (idx < lines.Length) {
            audioSource = lines[idx].GetComponent<AudioSource>();
            lines[idx].SetActive(true);
            
            lineText = lines[idx].GetComponent<TextMeshPro>();
            // lineStr = NormalizeText(lineText.text);
            
            yield return new WaitForSeconds(audioSource.clip.length);

            if (lineText.text == "Alone, I whisper,") {
                yield return new WaitForSeconds(1);
            } else if (lineText.text == "it's all your fault.") {
                // yield return new WaitForSeconds(1);
            } else if (lineText.text == "No, scratch that—") {
                yield return new WaitForSeconds(1);
            } else if (lineText.text == "it's all you.")
                FadeBgMusic();
            idx++;
        }
        yield return new WaitForSeconds(0.5f); // Debounce delay

        canAdvanceText = true; // Allow next trigger
    }

    public void FadeBgMusic()
    {
        StartCoroutine(FadeAudioSource.StartFade(finalBgMusic, 7, 0));
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
