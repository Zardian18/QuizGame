using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    //[Header("Question")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionScriptable> quizQuestions = new List<QuestionScriptable>();
    QuestionScriptable question;
    //[Header("Answer")]
    [SerializeField] GameObject[] answerButtons;
    int selectedAnswer;
    //[Header("Timer")]
    [SerializeField] Image timerImage;
    private Timer timer;
    //--------
    //[Header("Sprites")]
    [SerializeField]
    Sprite defaultSprite, correctSprite;//,wrongSprite
    public bool earlyAnswered;

    [SerializeField]
    TextMeshProUGUI scoreText;
    Score score;

    [SerializeField]
    Slider progressBar;

    public bool isComplete = false;
    void Start()
    {
        isComplete = false;
        progressBar.maxValue = quizQuestions.Count;
        progressBar.value = 0;
        score = FindObjectOfType<Score>();

        timer = FindObjectOfType<Timer>();
        DisplayQuestion();
        progressBar.value++;
        if (score != null)
        {
            score.QuestionAttemptIncrease();
        }
    }
    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            NextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!earlyAnswered && !timer.isAnswering)
        {
            ShowCorrectAnswer(-1);
            ChangeButtonState(false);
        }
    }
    void GetRandomQuestion()
    {
        int rand = Random.Range(0, quizQuestions.Count);
        question = quizQuestions[rand];
        if (quizQuestions.Contains(question))
        {
            quizQuestions.Remove(question);
        }
        if (quizQuestions.Count <= 0)
        {
            Debug.Log("Your score");
        }
        
    }
    void NextQuestion()
    {
        earlyAnswered = false;
        ChangeButtonState(true);
        GetRandomQuestion();
        SetDefaultButtonSprites();
        DisplayQuestion();
        score.QuestionAttemptIncrease();
        progressBar.value++;

    }
    public void ShowCorrectAnswer(int index)
    {
        Image buttonImg;
        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct Answer!";
            buttonImg = answerButtons[index].GetComponent<Image>();
            buttonImg.sprite = correctSprite;
        }

        else
        {
            int correctIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctIndex);
            questionText.text = "Correct answer is:\n" + correctAnswer;
            /*Image selectedButtonImg = answerButtons[index].GetComponent<Image>();
            selectedButtonImg.sprite = wrongSprite;*/
            buttonImg = answerButtons[correctIndex].GetComponent<Image>();
            buttonImg.sprite = correctSprite;
        }
    }

    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI button = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            button.text = question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        earlyAnswered = true;
        Image buttonImg;
        if (index== question.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct Answer!";
            buttonImg = answerButtons[index].GetComponent<Image>();
            buttonImg.sprite = correctSprite;
            score.CorrectAnswerIncreament();
            
        }

        else
        {
            int correctIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctIndex);
            questionText.text = "Correct answer is:\n" + correctAnswer;
            /*Image selectedButtonImg = answerButtons[index].GetComponent<Image>();
            selectedButtonImg.sprite = wrongSprite;*/
            buttonImg = answerButtons[correctIndex].GetComponent<Image>();
            buttonImg.sprite = correctSprite;
        }
        ChangeButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + score.ScoreCalc() + "%";
        if(progressBar.value== progressBar.maxValue)
        {
            isComplete=true;
        }
        //Invoke("NextQuestion", 5f);

    }
    
    void ChangeButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
            
            
        }
    }

    public void SetDefaultButtonSprites()
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            Image buttonImg = answerButtons[i].GetComponent<Image>();
            buttonImg.sprite = defaultSprite;
        }
    }
}
