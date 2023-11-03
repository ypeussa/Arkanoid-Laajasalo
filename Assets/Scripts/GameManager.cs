using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int lives = 3;
    Ball ball;
    void Awake() {
        ball = FindObjectOfType<Ball>();    
    }
    public void BallLost() {
        print("Ball lost!");
        lives--;
        if (lives <= 0) {
            print("Game over!"); // Debug.LogError if you want
        } else {
            ball.ResetBall();
        }
    }
}
