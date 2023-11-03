using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerupType { None, BigPaddle, SmallPaddle, ExtraLife }

public class PowerupItem : MonoBehaviour {
    public PowerupType powerup;
    void Awake() {
        Destroy(gameObject, 7f);    
    }

    void OnTriggerEnter2D(Collider2D coll) {
        Destroy(gameObject);
        FindObjectOfType<GameManager>().ActivatePowerup(powerup);

        // print("Hit the paddle! " + coll.name);
        // if (coll.gameObject.name == "Paddle") { }
        
    }
}
