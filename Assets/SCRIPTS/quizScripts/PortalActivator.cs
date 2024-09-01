using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalActivator : MonoBehaviour
{
    private int sceneNum;
    //public Animator fadeAnimator;
    public QuizActivator quizActivator;
    public GameObject fadescreen;
    public GameObject fadenum2;
    private string sceneName;
    public AudioSource bgMusic;


    // Start is called before the first frame update
    void Start()
    {
        sceneNum = -1;
        fadescreen.SetActive(false);
        sceneName = SceneManager.GetActiveScene().name;
        fadenum2.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")|| other.CompareTag("MainCamera"))
        {
            Debug.Log("Interacted!!");
            if (sceneName == "Freespirits") {
                StartCoroutine(FadeForFreeSpiritsDemo());
            } else
                StartCoroutine(LoadPoemScene());
        }
    }

// new brick solution for demo day yooeun 
    IEnumerator FadeForFreeSpiritsDemo() {
        StartCoroutine(FadeAudioSource.StartFade(bgMusic, 3, 0));

        fadescreen.SetActive(true);
        yield return new WaitForSeconds(3);
        fadenum2.SetActive(true);
    }


    private IEnumerator LoadPoemScene()
    {
        //fadeAnimator.SetTrigger("FadeOut");
        fadescreen.SetActive(true);

        sceneNum = quizActivator.getScene();

        yield return new WaitForSeconds(2);

        if (sceneNum == 1)
        {
            Debug.Log("fs load");
            SceneManager.LoadScene("Freespirits");
        }
        else if (sceneNum == 2)
        {
            Debug.Log("nurt load");
            SceneManager.LoadScene("Nurturers");
        }
        else if (sceneNum == 3)
        {
            Debug.Log("vis load");
            //SceneManager.LoadScene("Nurturers");

            SceneManager.LoadScene("Visionaries");
        }
        else
        {
            Debug.Log("something went wrong homie, heres scenenum: " + sceneNum);
        }
    }
}
