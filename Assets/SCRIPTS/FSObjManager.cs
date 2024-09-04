using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSObjManager : MonoBehaviour
{
    public GameObject butterfly; 

    public AnimationClip initialCircle;
    public AnimationClip toFirstStanza;
    public AnimationClip toEyesStanza;
    public AnimationClip toWishingWell; 
    public AnimationClip toStreetLight;
    public AnimationClip toMailBox;
    public AnimationClip toCompatibility;
    public AnimationClip toMirror; 
    public AnimationClip circlingAround; 

    private Animator animator;

    void Start()
    {
        animator = butterfly.GetComponent<Animator>();
    }

    public void MoveButterflyToDisco()
    {
        animator.Play("toEyesStanza");
    }


}
