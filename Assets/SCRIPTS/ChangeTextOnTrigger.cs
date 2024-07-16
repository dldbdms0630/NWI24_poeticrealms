using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using TMPro;


/* Changes text when the primary button is pressed. Ideally, would work with Gaze Interactor.
 * After that is done, then will implement sound associated with text as well. 
 */
public class ChangeTextOnTrigger : MonoBehaviour
{
    public TextMeshPro textObject;
    public string newText = "New Text DUMMY";

    private InputData inputData; 
    private bool isChanged = false, isGazed = false;



    private void Start()
    {
        inputData = GetComponent<InputData>();
        Debug.Log("Started inputData: " + inputData);
        // textObject = GameObject.Find("texts/poem1").GetComponent<TMP_Text>(); // added as bing rec 

    }

    void Update()
    {
        if (isGazed && inputData.rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool Abutton))
        {
            if (!isChanged && Abutton)
            ChangeText();
        }
    }

    void ChangeText()
    {
        textObject.text = newText;
        isChanged = true;
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
