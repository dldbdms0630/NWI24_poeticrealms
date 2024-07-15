using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizActivator : MonoBehaviour
{
    public QuizCalc calculateHomie;

    private int numQuestions;
    private int questionIndex;
    private Answers[] quizAnswers;

    enum Answers
    {
        FREE_SPIRIT,
        NURTURE,
        VISIONARY,
        FS_NURTURE, 
        FS_VISIONARY,
        NURTURE_VISIONARY,
        ALL,
        OTHER
    }

    [Header("Question Set")]
    public GameObject[] questionSets;
    public GameObject about;
    public GameObject options;

    //do allow USB debugging 

    // Start is called before the first frame update
    void Start()
    {
        numQuestions = questionSets.Length;
        quizAnswers = new Answers[numQuestions];

        BackToStart();

    }

    public void SelectFS()
    {
        calculateHomie.addFS();
        quizAnswers[questionIndex] = Answers.FREE_SPIRIT;

        ActivatorQuestionEnd();
    }
    public void SelectNur()
    {
        calculateHomie.addNur();
        quizAnswers[questionIndex] = Answers.NURTURE;

        ActivatorQuestionEnd();
    }
    public void SelectVis()
    {
        calculateHomie.addVis();
        quizAnswers[questionIndex] = Answers.VISIONARY;

        ActivatorQuestionEnd();
    }

    public void SelectFS_N()
    {
        calculateHomie.addFS();
        calculateHomie.addNur();
        quizAnswers[questionIndex] = Answers.FS_NURTURE;

        ActivatorQuestionEnd();
    }

    public void SelectFS_V()
    {
        calculateHomie.addFS();
        calculateHomie.addVis();
        quizAnswers[questionIndex] = Answers.FS_VISIONARY;

        ActivatorQuestionEnd();
    }

    public void SelectN_V()
    {
        calculateHomie.addNur();
        calculateHomie.addVis();
        quizAnswers[questionIndex] = Answers.NURTURE_VISIONARY;

        ActivatorQuestionEnd();
    }

    public void SelectAll()
    {
        calculateHomie.addNur();
        calculateHomie.addVis();
        calculateHomie.addFS();
        quizAnswers[questionIndex] = Answers.ALL;

        ActivatorQuestionEnd();
    }

    public void SelectOther()
    {
        //add smth here for the nothing thing, smth like calculateHomie.doSmth();
        quizAnswers[questionIndex] = Answers.OTHER;

        ActivatorQuestionEnd();
    }

    public void SelectAbout()
    {
        for (int i = 0; i < numQuestions; i++)
        {
            questionSets[i].SetActive(false);
        }

        about.SetActive(true);
    }
    public void SelectOptions()
    {
        for (int i = 0; i < numQuestions; i++)
        {
            questionSets[i].SetActive(false);
        }

        options.SetActive(true);
    }

    public void BackToStart()
    {
        about.SetActive(false);
        options.SetActive(false);

        // Load the first question without calling ActivatorQuestionEnd
        questionIndex = 0;
        loadQuestion();
    }

    public void BackButton()
    {
        //look at current question index --> go back 1, subtract whatever currently is there from calc
        if (questionIndex > 0) 
        {
            questionIndex--;
            
            if (quizAnswers[questionIndex] == Answers.FREE_SPIRIT)
            {
                calculateHomie.subtract(1);
            }
            else if (quizAnswers[questionIndex] == Answers.NURTURE)
            {
                calculateHomie.subtract(2);
            }
            else if (quizAnswers[questionIndex] == Answers.VISIONARY)
            {
                calculateHomie.subtract(3);
            }
            else if (quizAnswers[questionIndex] == Answers.FS_NURTURE)
            {
                calculateHomie.subtract(1);
                calculateHomie.subtract(2);
            }
            else if (quizAnswers[questionIndex] == Answers.FS_VISIONARY)
            {
                calculateHomie.subtract(1);
                calculateHomie.subtract(3);
            }
            else if (quizAnswers[questionIndex] == Answers.NURTURE_VISIONARY)
            {
                calculateHomie.subtract(2);
                calculateHomie.subtract(3);
            }
            else if (quizAnswers[questionIndex] == Answers.ALL)
            {
                calculateHomie.subtract(1);
                calculateHomie.subtract(2);
                calculateHomie.subtract(3);
            }
            else if (quizAnswers[questionIndex] == Answers.OTHER)
            {
                calculateHomie.subtract(4);
            }
            else
            {
                calculateHomie.subtract(-1);
            }
        }
        else
        {
            Debug.Log("???????????? HUH ??????????????? question index: " + questionIndex);
        }

        // Update the question activation state after decrementing the index
        loadQuestion();
    }

    public void ActivatorQuestionEnd()
    {
 
        calculateHomie.questionEnd();
        questionIndex++;
        
        loadQuestion();
    }

    private void loadQuestion()
    {
        if (questionIndex >= numQuestions)
        {
            //theres an end screen anyways so it doesn't matter (for now)
        }
        else
        {
            //sets questionIndex active 
            for (int i = 0; i < numQuestions; i++)
            {
                questionSets[i].SetActive(i == questionIndex);
            }
        }
    }

    public void QuizEnd()
    {
        calculateHomie.quizEnd();
        for (int i = 0; i < numQuestions; i++)
        {
            questionSets[i].SetActive(false);
        }
    }

    private void printCurrAnswers()
    {
        for(int i=0; i<questionIndex; i++)
        {
            Debug.Log("quizAnswers[" + questionIndex + "]: " + quizAnswers[questionIndex]);
        }
    }
}
