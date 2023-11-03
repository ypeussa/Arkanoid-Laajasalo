using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    public int hitpoints;
    public bool destructible;

    void OnCollisionEnter2D(Collision2D collision) {
        if (!destructible) {
            return;
        }
        hitpoints--;
        if (hitpoints <= 0) {
            Destroy(gameObject);
        }        
    }
}
