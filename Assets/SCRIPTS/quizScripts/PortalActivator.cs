using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalActivator : MonoBehaviour
{
    private int sceneNum;
    public Animator fadeAnimator;
    public QuizActivator quizActivator;

    // Start is called before the first frame update
    void Start()
    {
        sceneNum = -1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Interacted!!");
            LoadPoemScene();
        }
    }


    private void LoadPoemScene()
    {
        fadeAnimator.SetTrigger("FadeOut");

        sceneNum = quizActivator.getScene();

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
            SceneManager.LoadScene("Visionaries");
        }
        else
        {
            Debug.Log("something went wrong homie, heres scenenum: " + sceneNum);
        }
    }
}
