using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class FSObjManager : MonoBehaviour
{
    public GameObject butterfly; 
    public XRBaseController controllerR;


    public GameObject streetLight;
    public Material streetLightMat;
    public AnimationClip toDoorClip;
    public GameObject whiteDoor; 
    public GameObject computerScreen;
    public Material compatibilityMat;
    public GameObject handTrail;


    

    private Animation anim;
    private AudioSource phoneAlarm; 
    private AudioSource objAudio;
    private bool hapticsOn = false; 


    void Start()
    {
        anim = butterfly.GetComponent<Animation>();
        phoneAlarm = whiteDoor.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (hapticsOn)
        {
            controllerR.SendHapticImpulse(0.02f, 0.1f);
        }
    }
    public void MoveButterflyToDisco()
    {
        anim.Play("toStump");
    }

    public void MoveToSecondStump()
    {
        anim.Play("toSecondStump");
    }

    public void MoveButterflyToWishingWell()
    {
        anim.Play("toWishingWell");
    }

    public void TurnStreetLightOn()
    {
        streetLight.SetActive(true);
        streetLightMat.EnableKeyword("_EMISSION");
        Color orangeColor = new Color(1.0f, 0.4738789f, 0.0f); // RGB values for orange
        streetLightMat.SetColor("_EmissionColor", orangeColor * 1.4f);

        streetLightMat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.BakedEmissive;
    }


    public void MoveButterflyToStreetLight()
    {
        anim.Play("toStreetLight");
    }

    public void MoveButterflyToMailBox()
    {
        anim.Play("toMailBox");
    }

    public void EnableHandTrail()
    {
        hapticsOn = true; 
        handTrail.SetActive(true);
    }

    public void DisableHandTrail()
    {
        hapticsOn = false; 
        handTrail.SetActive(false);
    }

    public void MoveButterflyToComp()
    {
        // anim.Play("toComputer");
        anim.Play("toComp");
    }

    public IEnumerator EnableComputerEvent()
    {
        objAudio = computerScreen.GetComponent<AudioSource>();
        objAudio.Play();
        yield return new WaitForSeconds(2);

        computerScreen.GetComponent<MeshRenderer>().material = compatibilityMat;
    }


    public void MoveButterflyToMirror()
    {
        anim.Play("toMirror");
        
    }


    public void EnableDoor()
    {
        whiteDoor.SetActive(true);
    }

    public void FinalDoor()
    {
        StartCoroutine(PlayFinalDoorSequence());
    }

    private IEnumerator PlayFinalDoorSequence()
    {
        anim.Play("toDoor");
        yield return new WaitForSeconds(toDoorClip.length); // Wait for the toDoor animation to finish
        anim.Play("doorCircle");
    }



}
