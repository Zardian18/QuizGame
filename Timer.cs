using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float timeToComplete = 30f, timeToReview = 5f;
    public bool isAnswering = true;
    public bool loadNextQuestion;
    float timerValue;

    public float fillFraction;

    private Quiz quiz;
    // Start is called before the first frame update
    void Start()
    {
        quiz = FindObjectOfType<Quiz>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerUpdate();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
    void TimerUpdate()
    {
        timerValue -= Time.deltaTime;
        if (isAnswering)
        {
            if (timerValue <= 0)
            {
                isAnswering = false;
                //quiz.ShowCorrectAnswer();
                timerValue = timeToReview;
            }
            else
            {
                fillFraction = timerValue / timeToComplete;
            }
        }
        else
        {
            if (timerValue <= 0)
            {
                isAnswering = true;
                //quiz.SetDefaultButtonSprites();
                timerValue = timeToComplete;
                loadNextQuestion = true;
            }
            else
            {
                fillFraction = timerValue / timeToReview;
                
            }
        }

        
        
        Debug.Log(timerValue);
    }
}
