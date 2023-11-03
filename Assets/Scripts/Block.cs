using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    public int hitpoints;
    public bool destructible;
    public GameObject powerupPrefab;
    public BlockManager bm;

    void Awake() {
        if (bm == null) {
            bm = FindObjectOfType<BlockManager>();
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (!destructible) {
            return;
        }
        hitpoints--;
        if (hitpoints <= 0) {
            Destroy(gameObject);
            if (powerupPrefab != null) {
                Instantiate(powerupPrefab, transform.position, Quaternion.identity);
            }
            bm.BlockDestroyed();
        }        
    }
}
