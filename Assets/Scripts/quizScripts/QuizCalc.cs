using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class QuizCalc : MonoBehaviour
{
    private int freeSpiritScore;
    private int nurturerScore;
    private int visionaryScore;
    /*private int[] questionAnswers;
    private int currIndex;
    */

    // Start is called before the first frame update
    void Start()
    {
        freeSpiritScore = nurturerScore = visionaryScore = 0;
        //currIndex = 0;
    }

    public void addFS()
    {
        freeSpiritScore += 1;
    }

    public void addNur()
    {
        nurturerScore += 1;
    }

    public void addVis()
    {
        visionaryScore += 1;
    }
    public void subtract(int n)
    {
        if(n == 1)
        {
            freeSpiritScore -= 1;
        }
        else if(n == 2)
        {
            nurturerScore -= 1;
        }
        else if(n == 3)
        {
            visionaryScore -= 1;
        }
        else if (n == 4)
        {
            Debug.Log("other, not undoing anything");
        }
        else
        {
            Debug.Log("something went wrong, n passed into subtract: " + n);
        }

    }

    public void questionEnd()
    {
        int totalScore = freeSpiritScore + nurturerScore + visionaryScore;

        /*
        float FSPercentage = (float) freeSpiritScore * 100 / totalScore;
        float nurturerPercentage = (float) nurturerScore * 100 / totalScore;
        float visionaryPercentage = (100f - (FSPercentage + nurturerPercentage));

        Debug.Log("RAHHH FS: " + (int)System.Math.Round(FSPercentage, 0) + "% NURTURER: " +
            (int)System.Math.Round(nurturerPercentage, 0) + "% VISIONARY: " +
            (int)System.Math.Round(visionaryPercentage, 0) + "%");
        */

        Debug.Log("fs: " + freeSpiritScore + " nur: " + nurturerScore + " vis: " + visionaryScore);

        //currIndex++;
    }

    public int quizEnd()
    {
        if(visionaryScore > nurturerScore && visionaryScore > freeSpiritScore)
        {
            Debug.Log("YOURE A VISONARY aaaaaaaaaaaaa ");
            //SceneManager.LoadScene("Visionaries");
            return 3;
        }
        else if (freeSpiritScore > nurturerScore && freeSpiritScore > visionaryScore)
        {
            Debug.Log("freeeeeee spritei ");
            //SceneManager.LoadScene("Nurturers");
            return 1;
        }
        else
        {
            Debug.Log("nurtuerrer");
            //SceneManager.LoadScene("Freespirits");
            return 2;
        }
    }

}
