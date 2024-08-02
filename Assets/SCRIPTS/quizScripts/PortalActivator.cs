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

    // Start is called before the first frame update
    void Start()
    {
        sceneNum = -1;
        fadescreen.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Interacted!!");
            StartCoroutine(LoadPoemScene());
        }
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
            SceneManager.LoadScene("Nurturers");

            //SceneManager.LoadScene("Visionaries");
        }
        else
        {
            Debug.Log("something went wrong homie, heres scenenum: " + sceneNum);
        }
    }
}
