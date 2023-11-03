using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    public int lives = 3;
    public int score = 0;
    PermanentDataStore data;
    public GameObject datastorePrefab;

    Ball ball;
    public TMP_Text statusText;
    public TMP_Text scoreText;
    public Paddle paddle;
    public List<PowerupType> paddlePowerups;

    public void AddScore(int s) {
        score += s;
        // don't adjust the high score yet? wait till game over?
        UpdateScoreText();
    }
    void UpdateScoreText() {
        int scoreTextWidth = 6;
        string scoreString = score.ToString(); // (string)score;
        scoreString = scoreString.PadLeft(scoreTextWidth, '0');
        string highscoreString = data.highScore.ToString();
        highscoreString = highscoreString.PadLeft(scoreTextWidth, '0');
        var finalString = " Highscore: " +
                            ((score > data.highScore) ? scoreString : highscoreString);
        scoreText.text = "Score: " + scoreString + finalString;
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ResetGame();
        }
    }
    void ResetGame() {
        data.highScore = Mathf.Max(score, data.highScore);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    void Awake() {
        data = FindObjectOfType<PermanentDataStore>();
        if (data == null) {
            data = Instantiate(datastorePrefab).GetComponent<PermanentDataStore>();
            //var dataobj = Instantiate(datastorePrefab);
            //data = dataobj.GetComponent<PermanentDataStore>();
        }

        statusText.text = "";

        ball = FindObjectOfType<Ball>();
        UpdateScoreText();
    }
    void Pause() {
        Time.timeScale = 0;
    }
    void GameOverWin() {
        string hs = score > data.highScore ? "\nNew highscore!" : "";
        data.highScore = Mathf.Max(score, data.highScore);
        statusText.text = "Game over\nYou win!" + hs;
        Pause();
    }
    void GameOverLose() {
        string hs = score > data.highScore ? "\nNew highscore!" : "";
        data.highScore = Mathf.Max(score, data.highScore);
        statusText.text = "Game over!" + hs;
        Pause();
    }
    public void LastBlockDestroyed() {
        GameOverWin();
    }

    public void ActivatePowerup(PowerupType powerup) {
        print("Powerup activated: " + powerup);
        if (powerup == PowerupType.ExtraLife) {
            lives++;
            // TODO: update lives text
        } else if (paddlePowerups.Contains(powerup)) {
            paddle.ActivatePowerup(powerup);
        } else {
            Debug.LogError("Problematic powerup type, can't handle!");
        }
    }
    public void BallLost() {
        print("Ball lost!");
        lives--;
        if (lives <= 0) {
            GameOverLose();
        } else {
            ball.ResetBall();
        }
    }
}
