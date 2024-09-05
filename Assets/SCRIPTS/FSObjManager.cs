using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSObjManager : MonoBehaviour
{
    public GameObject butterfly; 

    //public AnimationClip initialCircle; // don't think we need this? 
    // public AnimationClip toFirstStanza;
    // private string toEyesStanza;
    // private string toWishingWell; 
    // private string toStreetLight;
    // private string toMailBox;
    // private string toCompatibility;
    // private string toMirror; 
    // private string toDoor;
    // private string circlingDoor;

    public GameObject streetLight;
    public Material streetLightMat;
    public AnimationClip toDoorClip;
    public GameObject whiteDoor; 

    

    private Animation anim;
    private AudioSource phoneAlarm; 

    void Start()
    {
        anim = butterfly.GetComponent<Animation>();
        phoneAlarm = whiteDoor.GetComponent<AudioSource>();
    }

    public void MoveButterflyToDisco()
    {
        anim.Play("first stump to second stump");
    }

    public void MoveButterflyToWishingWell()
    {
        anim.Play("toWishingWell");
    }

    public void TurnStreetLightOn()
    {
        streetLight.SetActive(true);
        streetLightMat.EnableKeyword("_EMISSION");
        streetLightMat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.None;
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
        return; 
    }

    public void MoveButterflyToComp()
    {
        anim.Play("toComp");
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
        anim.Play("circleDoor");
    }



}
