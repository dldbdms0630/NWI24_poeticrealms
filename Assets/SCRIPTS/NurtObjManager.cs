using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class NurtObjManager : MonoBehaviour
{
    /* 
     * All public GameObjects are to be assigned in Inspector. These are all
     * pieced together by the poems! Each method is called with the corresponding line.
    */
    // it just occurred to me that using tags is probably a better way BUT we have started already. 
    
    public GameObject frontSofaPortal;
    public GameObject firstStanza;

    public GameObject tvScreen; 
    // public VideoPlayer tvVideo;
    public GameObject firstLight;
    public Material topLightMaterial;
    public GameObject titleText;

    public GameObject polaroidPortal;
    public GameObject polaroidCamera;
    public GameObject polaroidText;
    public GameObject polaroidLight;
    public GameObject polaroids;

    public GameObject windowPortal;
    public GameObject windowText;
    public GameObject windowVideo;

    public GameObject handPortal;
    public GameObject handText;
    public GameObject handLight;
    // public Material arcLightMaterial;
    public GameObject handVideo;

    public GameObject firstWonderText;
    public GameObject firstWonderPortal;
    public GameObject wonderParticles;

    public GameObject computerPortal;
    public GameObject computerScreen;
    public GameObject computerText;
    public Material tableLightMat;
    public Material compatibilityMat;
    public Material blackMat;
    public GameObject tableLight;

    public GameObject secondToLastText;
    public GameObject smileyPortal;
    public GameObject smileyLight;
    public GameObject fadeScreen;
    public AudioSource nurtBgMusic;

    private string sceneName;

    public void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Nurturers")
            nurtBgMusic = firstStanza.GetComponent<AudioSource>();

        // } else if (sceneName == "NoFunNurt") {
        //     finalBgMusic = firstStanza.GetComponent<AudioSource>();
        // }
    }

    public void DisableTitle()
    {
        titleText.SetActive(false);
    }

    // public void PrepareTV() {
    //     tvVideo.Prepare();
    //     tvVideo.prepareCompleted += EnableTV;
    // }

    public void EnableTV()//(VideoPlayer vp)
    {
        tvScreen.SetActive(true);
        // tvVideo.Play();
        firstLight.SetActive(true);
        topLightMaterial.EnableKeyword("_EMISSION");
        topLightMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;

        // mat.DisableKeyword("_EMISSION");
        // mat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
        // mat.SetColor("_EmissionColor", Color.black);
    }

    public void EnablePolaroidOne()
    {
        // set active just the polaroid portal and camera and text
        frontSofaPortal.SetActive(false);
        // firstStanza.SetActive(false);
        // instead of disabling stanza, I want to trigger a fade-out animation. 
        polaroidPortal.SetActive(true);
        polaroidCamera.SetActive(true);
    }

    public void EnablePolaroidTwo()
    {
        polaroids.SetActive(true);
        polaroidLight.SetActive(true);
        // frontSofaPortal.SetActive(false);
        // firstStanza.SetActive(false);
    }

    public void EnableWindowPortal() 
    {
        polaroidPortal.SetActive(false);
        // polaroidText.SetActive(false);
        windowPortal.SetActive(true);
        // windowText.SetActive(true);
    }

    public void EnableWindowVideo()
    {
        windowVideo.SetActive(true);
    }

    public void EnableHandPortal() 
    {
        windowPortal.SetActive(false);
        // windowText.SetActive(false);
        handPortal.SetActive(true);
        // handText.SetActive(true);
    }

    public void EnableHandMovie()
    {
        handLight.SetActive(true);
        handVideo.SetActive(true);
    }

    public void EnableFirstWonder()
    {
        handPortal.SetActive(false);
        firstWonderPortal.SetActive(true);
        // handText.SetActive(false);
        // firstWonderText.SetActive(true);

    }

    public void EnableParticles()
    {
        wonderParticles.SetActive(true);
    }

    public void EnableComputerPortal()
    {
        // firstWonderText.SetActive(false);

        computerPortal.SetActive(true);
        // computerText.SetActive(true);
    }

    public void EnableComputerEvent()
    {
        // FindObjectOfType<ChangeTextOnTrigger>().canAdvanceText = false;

        computerScreen.GetComponent<MeshRenderer> ().material = compatibilityMat;
        tableLight.SetActive(true);
        tableLightMat.EnableKeyword("_EMISSION");
        tableLightMat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;

    }

    public void OnComputerScreenTouched()
    {
        // FindObjectOfType<ChangeTextOnTrigger>().canAdvanceText = true;
    }

    public void EnableSecondToLast()
    {   
        computerPortal.SetActive(false);
        smileyPortal.SetActive(true);
        // computerText.SetActive(false);
        
        // secondToLastText.SetActive(true);
    }


    public void EnableSmileyStanza()
    {
        smileyLight.SetActive(true);
        // arcLightMaterial.EnableKeyword("_EMISSION");
        // arcLightMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;

    }


    public IEnumerator GoToLastStanza()
    {
        StartCoroutine(FadeAudioSource.StartFade(nurtBgMusic, 5, 0));
        fadeScreen.SetActive(true);

        // topLightMaterial.DisableKeyword("_EMISSION");
        // topLightMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
        // topLightMaterial.SetColor("_EmissionColor", Color.black);

        // tableLightMat.DisableKeyword("_EMISSION");
        // tableLightMat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
        // tableLightMat.SetColor("_EmissionColor", Color.black);

        // computerScreen.GetComponent<MeshRenderer> ().material = blackMat;

        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("NoFunNurt");
        topLightMaterial.DisableKeyword("_EMISSION");
        topLightMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
        topLightMaterial.SetColor("_EmissionColor", Color.black);

        tableLightMat.DisableKeyword("_EMISSION");
        tableLightMat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
        tableLightMat.SetColor("_EmissionColor", Color.black);

        computerScreen.GetComponent<MeshRenderer> ().material = blackMat;
    }


    // public void FadeBgMusic()
    // {
    //     StartCoroutine(FadeAudioSource.StartFade(finalBgMusic, 5, 0));

    // }


    // public void DisableObjects()
    // {
    //     cubeForScreen.SetActive(false);
    //     lightObject.SetActive(false);
    // }
}
