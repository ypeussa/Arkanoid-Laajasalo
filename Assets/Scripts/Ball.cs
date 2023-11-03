using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Vector2 launchDir;
    public float speed;

    Rigidbody2D rb;

    void ResetBall() {
        rb.velocity = launchDir.normalized * speed;
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        ResetBall();
    }
}
