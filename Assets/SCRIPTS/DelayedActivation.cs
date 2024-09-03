using System.Collections;
using UnityEngine;

public class DelayedActivation : MonoBehaviour
{
    public float secsToWait = 3f;
    public GameObject targetGameObject;

    void Start() 
    {
        StartCoroutine(ActivateAfterDelay());
    }

    private IEnumerator ActivateAfterDelay()
    {
        targetGameObject.SetActive(false); // Ensure the target game object is disabled at start
        yield return new WaitForSeconds(secsToWait);
        targetGameObject.SetActive(true); // Enable the target game object after the delay
    }
}
