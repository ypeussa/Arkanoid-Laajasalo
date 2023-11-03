using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickDemo : MonoBehaviour
{
    public float tick = 2f;
    float timer = 0f;

    void Update() {
        timer += Time.deltaTime;
        if (timer > tick) {
            print("TICK");
            timer = 0f;
        }
    }
}
