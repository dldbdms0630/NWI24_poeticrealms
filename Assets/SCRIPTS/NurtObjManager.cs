using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
    public GameObject handVideo;


    public void DisableTitle()
    {
        titleText.SetActive(false);
    }

    public void EnableTV()
    {
        tvScreen.SetActive(true);
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
        firstStanza.SetActive(false);
        polaroidPortal.SetActive(true);
        polaroidCamera.SetActive(true);
        polaroidText.SetActive(true);
    }

    public void EnablePolaroidTwo()
    {
        // set active light in lamp, all of the 6 polaroids (just use parent), 
        polaroids.SetActive(true);
        polaroidLight.SetActive(true);
        // frontSofaPortal.SetActive(false);
        // firstStanza.SetActive(false);
    }

    public void EnableWindowPortal() 
    {
        polaroidPortal.SetActive(false);
        polaroidText.SetActive(false);
        windowPortal.SetActive(true);
        windowText.SetActive(true);
    }

    public void EnableWindowVideo()
    {
        windowVideo.SetActive(true);
    }

    public void EnableHandPortal() 
    {
        windowPortal.SetActive(false);
        windowText.SetActive(false);
        handPortal.SetActive(true);
        handText.SetActive(true);
    }

    public void EnableHandMovie()
    {
        handLight.SetActive(true);
        handVideo.SetActive(true);

    }

    public void EnableFirstWonder()
    {

    }

    public void EnableParticles()
    {

    }

    public void EnableComputerPortal()
    {

    }

    public void EnableComputerEvent()
    {
        FindObjectOfType<ChangeTextOnTrigger>().canAdvanceText = false;


    }

    public void OnComputerScreenTouched()
    {
        FindObjectOfType<ChangeTextOnTrigger>().canAdvanceText = true;
    }

    public void EnableSecondToLast()
    {

    }


    public void EnableSmileyStanza()
    {
        // get back to portal that we have disabled 
        // turn arc light on
        // turn "I open my lips and" text on

    }


    public void GoToLastStanza()
    {
        SceneManager.LoadScene("NoFunNurt");
    }



    // public void DisableObjects()
    // {
    //     cubeForScreen.SetActive(false);
    //     lightObject.SetActive(false);
    // }
}
