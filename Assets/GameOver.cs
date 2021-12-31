using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text gameOverScore;
    public void getScore(){
        gameOverScore.text = "Score: " + ScoreScript.scoreValue;
    }
    public void Setup(){
        gameObject.SetActive(true);
    }

    public void RestartButton(){
        SceneManager.LoadScene("Game");
    }

    public void ExitButton(){
        SceneManager.LoadScene("MainMenu");
    }
}
