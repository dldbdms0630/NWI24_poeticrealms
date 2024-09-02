using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class VisionaryText : MonoBehaviour
{
    [System.Serializable]
    public class TextAudioPair
    {
        public string text;
        public AudioClip audioClip;
    }
    public List<TextAudioPair> textAudioPairs; // List of text and audio clip pairs
    public GameObject visionBlockQuad; 
    public GameObject textObj; // text object for poem 

    private TextMeshPro textTMP;
    private bool canAdvanceText = true; // for controlling timing of interactions and text
    private InputData inputData;
    private AudioSource poemSound; 

    private AudioSource quadDisableSound; 
    private MeshRenderer quadRenderer; // do quadRenderer.enabled = false; instead of quad.SetActive(false); bc that'll end the quad audio as well 

    private int i = 0; // for counting index 

    public GameObject DREAMEDOFYOULASTNIGHT;
    public GameObject toSpawn;
    public GameObject toSpawn2;



    // Start is called before the first frame update
    void Start()
    {
        poemSound = textObj.GetComponent<AudioSource>();
        quadDisableSound = visionBlockQuad.GetComponent<AudioSource>();
        quadRenderer = visionBlockQuad.GetComponent<MeshRenderer>();
        inputData = GetComponent<InputData>();
        textTMP = textObj.GetComponent<TextMeshPro>();


        StartCoroutine(FirstLineQuadDisable());
        
    }

    IEnumerator FirstLineQuadDisable() {
        yield return new WaitForSeconds(poemSound.clip.length + 1);
        quadDisableSound.Play();
        yield return new WaitForSeconds(0.3f);
        quadRenderer.enabled = false;
        
        DREAMEDOFYOULASTNIGHT.SetActive(false);
    }

    void Update()
    {
        if (inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton)) {
            if (Abutton && !poemSound.isPlaying && canAdvanceText) {
                StartCoroutine(ChangeText());
            }
        }
    }



    IEnumerator ChangeText()
    {
        if (i < textAudioPairs.Count)
        {
            TextAudioPair pair = textAudioPairs[i];
            textTMP.text = pair.text;
            poemSound.clip = pair.audioClip;
            poemSound.Play();

            if(pair.text == "We ran away from robots—those brainsick bots— ")
            {
                Debug.Log("AAAAAAAAAAAAA THERE IS SPAZE");
                toSpawn.SetActive(true);

            }


            i++;
            canAdvanceText = false;

            yield return new WaitForSeconds(pair.audioClip.length);
            canAdvanceText = true;
        }
    }
}
