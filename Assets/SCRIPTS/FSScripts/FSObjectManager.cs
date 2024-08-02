using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FSObjectManager : MonoBehaviour
{

    public GameObject firstStanza;

    public GameObject titleText;

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
