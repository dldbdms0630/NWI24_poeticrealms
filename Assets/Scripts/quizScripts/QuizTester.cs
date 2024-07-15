using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTester : MonoBehaviour
{
    public QuizCalc calculateHomie;

    // Start is called before the first frame update
    void Start()
    {
        calculateHomie.addFS();
        calculateHomie.addNur();
        calculateHomie.addFS();
        calculateHomie.questionEnd();

        calculateHomie.addFS();
        calculateHomie.addVis();
        calculateHomie.questionEnd();

        calculateHomie.addVis();
        calculateHomie.questionEnd();

        calculateHomie.quizEnd();
    }

}
