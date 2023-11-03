using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public float speed;
    public float powerupTimeout = 4f;
    float powerupTimer = 0f;
    PowerupType currentState = PowerupType.None;

    void Update() {
       if (currentState != PowerupType.None) {
            powerupTimer += Time.deltaTime;
            if (powerupTimer > powerupTimeout) {
                ActivatePowerup(PowerupType.None);
            }
        }    
    }
    public void ActivatePowerup(PowerupType newPowerup) {
        print("Was in state: " + currentState + ", new state is " + newPowerup);
        powerupTimer = 0f;
        EndPaddleState(currentState);
        StartPaddleState(newPowerup);
        currentState = newPowerup;
    }

    void StartPaddleState(PowerupType starting) {
        if (starting == PowerupType.BigPaddle) {
            transform.localScale = new Vector3(1.5f, 1, 1);
        }
        else if (starting == PowerupType.SmallPaddle) {
            transform.localScale = new Vector3(0.5f, 1, 1);
        }
    }
    void EndPaddleState(PowerupType ending) {
        if (ending == PowerupType.BigPaddle) {
            transform.localScale = Vector3.one;
        } else if (ending == PowerupType.SmallPaddle) {
            transform.localScale = Vector3.one;
        }
    }


    void Start() {

    }

    void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        // Vector3.right == new Vector(1, 0, 0)
        var delta = speed * horizontal * Vector3.right * Time.deltaTime;
        transform.position += delta;
    }
}
