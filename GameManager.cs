using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    EndScreen endScreen;

    // Start is called before the first frame update
    void Start()
    {
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<EndScreen>();
        if (quiz != null)
        {
            quiz.gameObject.SetActive(true);
        }
        if (endScreen != null)
        {
            endScreen.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (quiz.isComplete)
        {
            endScreen.gameObject.SetActive(true);
            endScreen.FinalScore();
            quiz.gameObject.SetActive(false);
        }
    }
}
