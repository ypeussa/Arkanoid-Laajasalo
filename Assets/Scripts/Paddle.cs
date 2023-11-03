using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public float speed;

    void Start() {

    }

    void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        // Vector3.right == new Vector(1, 0, 0)
        var delta = speed * horizontal * Vector3.right * Time.deltaTime;
        transform.position += delta;
    }
}
