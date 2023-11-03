using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLostTrigger : MonoBehaviour {
    GameManager gm;
    void Awake() {
        gm = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D collision) {
        gm.BallLost();
    }
}
