using System.Collections;
using UnityEngine;

public class DelayedActivation : MonoBehaviour
{
    public int secsToWait = 3;
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
