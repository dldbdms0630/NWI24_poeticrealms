using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System;

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
    public XRBaseController controllerR;
    public Transform playerTransform;

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
    public AudioSource bgMusicToStart;
    public ParticleSystem starparticles;

    [Header("searching fearless eyes")]
    public AudioSource projector1;
    public GameObject allshells;
    public ObjectConverter converter1;
    public ObjectConverter converter2;
    public ObjectConverter converter3;
    public ObjectConverter converter4;

    [Header("like frantic wishes")]
    public AudioSource projector2;
    public AudioSource clockTicking;

    [Header("32% compatibility")]
    public GameObject stars;

    [Header("every single smiley")]
    public ParticleSystem smileyparticles;

    [Header("hand in hand")]
    public GameObject handParticles;
    private bool hapticsOn = false;

    [Header("have our prayers")]
    public GameObject lightScreen;
    private Animator lightScreenAnim;

    [Header("flutter stomach rides")]
    public AudioSource rollercoastersound;

    [Header("i wake up ... (final part)")]
    public GameObject IWAKEUP;
    public GameObject ALONEIWHISPER;
    public GameObject ALLYOURFAULT;
    public GameObject SCRATCHTHAT;
    public GameObject ITSALLYOU;

    public GameObject blurShader;

    [Header("testing converter")]
    public ObjectConverter converter;


    // Start is called before the first frame update
    void Start()
    {
        smileyparticles.Stop();
        smileyparticles.Clear();
        //just to be sure things work, disabling stuff here
        toSpawn.SetActive(false);
        toSpawn2.SetActive(false);
        //bgMusicToStart.SetActive(false);
        allshells.SetActive(false);

        // UNCOMMMENET ALLALEREYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY
        stars.SetActive(false);
        handParticles.SetActive(false);
        IWAKEUP.SetActive(false);
        starparticles.Play();
        lightScreen.SetActive(true);
        lightScreenAnim = lightScreen.GetComponent<Animator>();

        //lightScreen.SetActive(false);

        poemSound = textObj.GetComponent<AudioSource>();
        quadDisableSound = visionBlockQuad.GetComponent<AudioSource>();
        quadRenderer = visionBlockQuad.GetComponent<MeshRenderer>();
        inputData = GetComponent<InputData>();
        textTMP = textObj.GetComponent<TextMeshPro>();


        StartCoroutine(FirstLineQuadDisable());

        //THIS IS JSUT FOR TSTING USING THE SIMULATOR PLEASE DELETE THIS BEFORE THE THING ENDS !!!!!!!!!!!!!!!!!!!!!!!
        //StartCoroutine(ChangeText());


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
        /*if (!poemSound.isPlaying && canAdvanceText)
        {
            StartCoroutine(ChangeText());
        }*/

        
        if (inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton)) {
            if (Abutton && !poemSound.isPlaying && canAdvanceText) {
                StartCoroutine(ChangeText());
            }
        }
        

        if (hapticsOn)
        {
            controllerR.SendHapticImpulse(0.02f, 0.1f);
        }
    }


    //wamt to implement:
    /// sounds for shooting stasrs
    /// maybe make it where the user faces at the time
    /// deathtouch implement
    /// sound of running
    /// 
    /// add running sound for ran away from robots
    /// whiteboard sound effect for foggy glass
    /// 
    /// 
    /// subtle twinkle sound 
    /// 
    /// </summary>
    /// <returns></returns>

    IEnumerator ChangeText()
    {
        if (i < textAudioPairs.Count)
        {
            canAdvanceText = false;
            TextAudioPair pair = textAudioPairs[i];
            textTMP.text = pair.text;
            poemSound.clip = pair.audioClip;

            //weird special cases, cuz these have to happen before yooeun talks lmao
            if (pair.text == "Let 'em hear the hymns of your searching-fearless eyes,")
            {
                quadRenderer.enabled = true;
                projector1.Play();
                yield return new WaitForSeconds(0.7f);
                quadRenderer.enabled = false;
            }
            if (pair.text == "like frantic wishes at 11:11,")
            {
                quadRenderer.enabled = true;
                projector2.Play();
                clockTicking.Play();
                converter1.Convert();
                converter2.Convert();
                converter3.Convert();
                converter4.Convert();
                yield return new WaitForSeconds(0.7f);
                quadRenderer.enabled = false;

            }
            if (pair.text == "it's all you.")
            {
                quadRenderer.enabled = true;
                allshells.SetActive(false);
                yield return new WaitForSeconds(1);
            }

            poemSound.Play();

            if (pair.text == "We ran away from robots—those brainsick bots— ")
            {
                //toSpawn.SetActive(true);

                //converter.Convert();

            }
            else if (pair.text == "Let 'em hear the hymns of your searching-fearless eyes,")
            {
                //special case
                allshells.SetActive(true);
            }
            else if (pair.text == "like frantic wishes at 11:11,")
            {
                //special case
            }
            //hand sparkle particles turn on, until "we keep running"
            else if (pair.text == "hand in hand—we're running hand in hand—")
            {
                Debug.Log("activate hand");
                handParticles.SetActive(true);
                hapticsOn = true;
            }
            else if (pair.text == "'cause you never did great with the")
            {
                handParticles.SetActive(false);
                hapticsOn = false;
                rollercoastersound.Play();
            }
            else if (pair.text == "flutter-stomach-rides, but")
            {
                //rollercoastersound.Play();
            }
            else if (pair.text == "have our prayers reached the right destination—to our God?")
            {
                //lightScreen.SetActive(true);
                lightScreenAnim.SetTrigger("startFade");
            }
            else if (pair.text == "why do I hold you like you will slip away?")
            {
                lightScreenAnim.SetTrigger("endFade");
            }
            else if (pair.text == "telling me to trust you over our 32-percent-compatibility,")
            {
                //lightScreen.SetActive(false);
                stars.SetActive(true);

                // Only match the Y axis rotation (for horizontal rotation)
                Vector3 playerEulerAngles = playerTransform.eulerAngles;
                stars.transform.rotation = Quaternion.Euler(0, (playerEulerAngles.y), 0);
            }
            else if (pair.text == "like I-see-you-in-every-single smiley—")
            {
                smileyparticles.Play();
            }
            //this is a really roundabout way of doing this but ig it works 
            else if (pair.text == "I wake up, my hand casted in the shape of us.")
            {
                smileyparticles.Stop();
                //blurShader.SetActive(true);
                //IWAKEUP.SetActive(true);
            }
            else if (pair.text == "Alone, I whisper,")
            {
                //IWAKEUP.SetActive(false);
                //ALONEIWHISPER.SetActive(true);
            }
            else if (pair.text == "it's all your fault.")
            {
                //ALONEIWHISPER.SetActive(false);

                blurShader.SetActive(true);
                bgMusicToStart.Pause();

                ALLYOURFAULT.SetActive(true);
            }
            else if (pair.text == "No, scratch that—")
            {
                ALLYOURFAULT.SetActive(false);
                bgMusicToStart.UnPause();

                blurShader.SetActive(false);

                //SCRATCHTHAT.SetActive(true);
            }
            else if (pair.text == "it's all you.")
            {
                //SCRATCHTHAT.SetActive(false);
                //bgMusicToStart.Pause();

                ITSALLYOU.SetActive(true);

            }
            i++;
            

            yield return new WaitForSeconds(pair.audioClip.length);
            canAdvanceText = true;
        }
    }
}
