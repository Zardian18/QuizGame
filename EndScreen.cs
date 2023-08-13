using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI finalText;

    Score score;

    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinalScore()
    {
        finalText.text = "Congratulations!\nYou Scored " + score.ScoreCalc() + " %";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
