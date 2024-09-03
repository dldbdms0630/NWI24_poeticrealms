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
    [Header("General Stuff")]
    public List<TextAudioPair> textAudioPairs; // List of text and audio clip pairs
    public GameObject textObj; // text object for poem 

    public GameObject toSpawn;
    public GameObject toSpawn2;

    private TextMeshPro textTMP;
    private bool canAdvanceText = true; // for controlling timing of interactions and text
    private InputData inputData;
    private AudioSource poemSound; 

    private AudioSource quadDisableSound; 
    private MeshRenderer quadRenderer; // do quadRenderer.enabled = false; instead of quad.SetActive(false); bc that'll end the quad audio as well 

    private int i = 0; // for counting index 

    [Header("dreamed of you last night")]
    public GameObject visionBlockQuad;
    public GameObject DREAMEDOFYOULASTNIGHT;
    public GameObject bgMusicToStart;


    [Header("like frantic wishes")]
    public GameObject clocks;

    [Header("32% compatibility")]
    public GameObject stars;

    [Header("i wake up ... (final part)")]
    public GameObject IWAKEUP;
    public GameObject ALONEIWHISPER;
    public GameObject ALLYOURFAULT;
    public GameObject SCRATCHTHAT;

    public GameObject blurShader;


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
        //yield return new WaitForSeconds(1f);
        //bgMusicToStart.SetActive(true);
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
            else if(pair.text == "like frantic wishes at 11:11,")
            {
                clocks.SetActive(true);
            }
            else if(pair.text == "telling me to trust you over our 32-percent-compatibility,")
            {
                stars.SetActive(true);
            }
            //this is a really roundabout way of doing this but ig it works 
            else if(pair.text == "I wake up, my hand casted in the shape of us.")
            {
                blurShader.SetActive(true);
                IWAKEUP.SetActive(true);
            }
            else if(pair.text == "Alone, I whisper,")
            {
                IWAKEUP.SetActive(false);
                ALONEIWHISPER.SetActive(true);
            }
            else if(pair.text == "it's all your fault.")
            {
                ALONEIWHISPER.SetActive(false);
                ALLYOURFAULT.SetActive(true);
            }
            else if (pair.text == "No, scratch that—")
            {
                ALLYOURFAULT.SetActive(false);
                SCRATCHTHAT.SetActive(true);
            }
            else if(pair.text == "it's all you.")
            {
                SCRATCHTHAT.SetActive(false);
                blurShader.SetActive(false);
            }
            i++;
            canAdvanceText = false;

            yield return new WaitForSeconds(pair.audioClip.length);
            canAdvanceText = true;
        }
    }
}
