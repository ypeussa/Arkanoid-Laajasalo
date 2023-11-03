using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour {
    public float speed;
    public Vector2 direction;

    void Start() {
        //If you were using a physical rigidbody to move the object:
        //GetComponent<Rigidbody2D>().velocity = (Vector3)direction.normalized * speed;
    }

    void Update() {
        transform.position += (Vector3)direction.normalized * speed * Time.deltaTime;
    }
}
