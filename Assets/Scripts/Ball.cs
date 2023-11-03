using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public Vector2 launchDir;
    public float speed;
    public float minAngle;
    bool goingUp;

    Rigidbody2D rb;

    void FixedUpdate() {
        //if (rb.velocity.y > 0) {
        //    goingUp = true;
        //} else {
        //    goingUp = false;
        //}
        goingUp = rb.velocity.y > 0;
    }
    void OnCollisionExit2D(Collision2D collision) {
        Quaternion minAngleClockwise = Quaternion.Euler(0, 0, -minAngle);
        Quaternion minAngleCounterClockwise = Quaternion.Euler(0, 0, minAngle);

        float leftAngle = Vector2.Angle(rb.velocity, Vector2.left);
        if (leftAngle < minAngle) {
            print("going too horizontal left");
            if (goingUp) {
                print("correcting angle to left/up");
                var newVelocity = minAngleClockwise * Vector2.left;
                newVelocity *= speed;
                rb.velocity = newVelocity;
            } else {
                print("correcting angle to left/down");
                var newVelocity = minAngleCounterClockwise * Vector2.left;
                newVelocity *= speed;
                rb.velocity = newVelocity;
            }
        }
        // TODO STUDENTS: do same for situations where ball bounces
        // (almost) directly to the right!
    }
    void ResetBall() {
        rb.velocity = launchDir.normalized * speed;
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        ResetBall();
    }
}
