using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionScriptable : ScriptableObject
{
    [TextArea(2, 5)]
    [SerializeField] string question = "Enter Question here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int solution;

    public string GetQuestion()
    {

        return question;
    }
    public int GetCorrectAnswerIndex()
    {
        return solution;
    }
    public string GetAnswer(int ind)
    {
        return answers[ind];
    }
    
}
