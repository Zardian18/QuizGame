using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    int correctAns = 0;
    int quesAttempt = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuestionAttemptIncrease()
    {
        quesAttempt++;
    }
    public void CorrectAnswerIncreament()
    {
        correctAns++;
    }
    public int GetCorrectAnswers()
    {
        return correctAns;
    }
    public int GetQuestionAttempted()
    {
        return quesAttempt;
    }

    public int ScoreCalc()
    {
        return Mathf.RoundToInt((correctAns / (float)quesAttempt) * 100);
    }
}
