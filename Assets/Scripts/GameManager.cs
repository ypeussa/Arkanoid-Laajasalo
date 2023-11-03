using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    public int lives = 3;
    Ball ball;
    public TMP_Text statusText;
    public Paddle paddle;
    public List<PowerupType> paddlePowerups;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ResetGame();
        }
    }
    void ResetGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    void Awake() {
        statusText.text = "";

        ball = FindObjectOfType<Ball>();    
    }
    void Pause() {
        Time.timeScale = 0;
    }
    void GameOverWin() {
        statusText.text = "Game over\nYou win!";
        Pause();
    }
    void GameOverLose() {
        statusText.text = "Game over\nYou lose!";
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
