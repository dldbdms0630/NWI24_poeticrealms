using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FSObjectManager : MonoBehaviour
{
    [Header("title stuff")]
    public GameObject titleText;

    [Header("stanza 1 dreamed")]
    public GameObject firstStanza;

    [Header("stanza 1.5 (hymn eyes)")]
    public GameObject hymnsEyesText;

    [Header("stanza 2 seashells")]
    public GameObject secondStanza;

    [Header("stanza 3/4 still running")]
    public GameObject thirdFourthStanza;

    [Header("first wonder")]
    public GameObject wonderText;

    [Header("stanza 5 32 percent")]
    public GameObject fifthStanza;

    [Header("stanza 6 every single smiley")]
    public GameObject sixthStanza;

    [Header("other")]
    private string sceneName;
    public AudioSource fsBgMusic;

    public void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Freespirits")
            fsBgMusic = firstStanza.GetComponent<AudioSource>();

        // } else if (sceneName == "NoFunNurt") {
        //     finalBgMusic = firstStanza.GetComponent<AudioSource>();
        // }
    }

    public void DisableTitle()
    {
        titleText.SetActive(false);
    }

    /*
    public IEnumerator GoToLastStanza()
    {

        // PROBABLY DO SMTH DIFF WITH THE AUDIO, THIS IS JUST WHAT THE NURTURERS DID
        StartCoroutine(FadeAudioSource.StartFade(fsBgMusic, 5, 0));
        //fadeScreen.SetActive(true);

        // topLightMaterial.DisableKeyword("_EMISSION");
        // topLightMaterial.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
        // topLightMaterial.SetColor("_EmissionColor", Color.black);

        // tableLightMat.DisableKeyword("_EMISSION");
        // tableLightMat.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
        // tableLightMat.SetColor("_EmissionColor", Color.black);

        // computerScreen.GetComponent<MeshRenderer> ().material = blackMat;

        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("NoFunNurt");
    }
    */
}
