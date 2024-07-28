using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerPoem : MonoBehaviour
{
    public GameObject poem;
    private TextMeshPro poemText;

    public string[] lines = {"New Text A", "New Text B", "New Text C", "New Text D"};
    public AudioClip[] audioClips;




    // public NurtObjManager nurtObjManager;

    
    /* audioSource to play the clips; remember to add first audio on here so would play automatically */ 
    private AudioSource audioSource; 
    private InputData inputData;

    void Start() {
        poemText = poem.GetComponent<TextMeshPro>();
        audioSource = poem.GetComponent<AudioSource>();

        // poemText.text = "TEST"; this works woohoo 
    }


    // void Update()
    // {
    //     if (isGazed && canAdvanceText && inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton))
    //     {
    //         if (!isStanzaDone && Abutton && !audioSource.isPlaying)
    //         // ChangeText();
    //         StartCoroutine(ChangeText());
    //     }
    // }

    // IEnumerator ChangeText()
    // {
    //     if (textIdx < newTexts.Length) {
    //         textObject.text = newTexts[textIdx];
    //         audioSource.clip = audioClips[textIdx];
    //         audioSource.Play();
    //         yield return new WaitForSeconds(audioSource.clip.length);


    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "PlayerBody") {
            poem.SetActive(true);
        }
    }

}
