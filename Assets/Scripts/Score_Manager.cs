using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score_Manager : MonoBehaviour
{
    public int score = 0;
    public int highScore;
    public Text scoreText;
    public Text HighScoreText;


    void Start()
    {
        StartCoroutine(Score());
        highScore = PlayerPrefs.GetInt("high_score" , 0);;
        HighScoreText.text =  highScore.ToString();
    }

    
    void Update()
    {
       scoreText.text = score.ToString();
       if (score > highScore) {
            highScore = score;
            PlayerPrefs.SetInt("high_score", highScore);
                }
        
    }

    IEnumerator Score() {
        while(true){
        yield return new WaitForSeconds(2);
        score = score + 1;
         }
    }

    
}
