using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightFader : MonoBehaviour
{
    private Light lightToFade;
    public float fadeDuration = 2.0f; // Duration of the fade-in effect

    private void Awake()
    {
        lightToFade = GetComponent<Light>(); // Automatically get the Light component on the same GameObject
    }

    private void OnEnable()
    {
        if (lightToFade != null)
        {
            StartCoroutine(FadeInLight());
        }
        else
        {
            Debug.LogError("No Light component found on this GameObject.");
        }
    }

    private IEnumerator FadeInLight()
    {
        float startIntensity = 0f;
        float endIntensity = lightToFade.intensity;
        lightToFade.intensity = startIntensity;

        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            lightToFade.intensity = Mathf.Lerp(startIntensity, endIntensity, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        lightToFade.intensity = endIntensity;
    }
}
