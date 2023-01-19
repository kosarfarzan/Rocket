using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public int highScore;
    public static int lastScore = 0;
    public Text HighScoreText;
    public Text lastScoreText;


    void Start()
    {
        StartCoroutine(Score());
        highScore = 0;
        Debug.Log("high score stored:" + PlayerPrefs.GetInt("high_score", highScore));

    }

    
    void Update()
    {
       scoreText.text = score.ToString();
       if (score > highScore) {
            highScore = score;
            Debug.Log(highScore);
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
