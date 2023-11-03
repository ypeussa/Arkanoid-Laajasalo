using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {
    public int nx = 5;
    public float dx = 2f;
    public int ny = 4;
    public float dy = 1f;

    public float powerupProbability = 0.2f;
    public GameObject[] spawnablePowerups;

    public GameObject normalBlockPrefab;
    public GameObject durableBlockPrefab;
    public GameObject indestructibleBlockPrefab;

    public float durableBlockChance;
    public float indestructibleBlockChance;

    public Transform blocksFolder;

    public GameManager gm;
    int breakableBlocksLeft;

    public void BlockDestroyed() {
        breakableBlocksLeft--;
        gm.AddScore(100);
        if (breakableBlocksLeft <= 0) {
            // print("All blocks destroyed");
            gm.LastBlockDestroyed();
        }
    }
    void CountBreakableBlocks() {
        breakableBlocksLeft = 0;
        var allBlocks = FindObjectsOfType<Block>();
        foreach (var block in allBlocks) {
            if (block.destructible) {
                breakableBlocksLeft++;
            }
        }
    }

    GameObject RandomizeBlockPrefab() {
        float rnd = Random.value;
        if (rnd < durableBlockChance) {
            return durableBlockPrefab;
        } else if (rnd < durableBlockChance + indestructibleBlockChance) {
            return indestructibleBlockPrefab;
        }
        return normalBlockPrefab;
    }
    void Start() {
        //var newBlock = Instantiate(normalBlockPrefab);
        //newBlock.transform.position = transform.position;
        var c = transform.position;

        for (int j = 0; j < ny; j++) {
            for (int i = 0; i < nx; i++) {
                var go = Instantiate(RandomizeBlockPrefab());
                float x0 = (nx - 1) * 0.5f * dx;
                float newX = c.x - x0 + i * dx;
                float newY = c.y - j * dy;
                go.transform.position = new Vector2(newX, newY);
                go.transform.parent = blocksFolder;
                var block = go.GetComponent<Block>();
                block.bm = this;
                if (Random.value < powerupProbability) {
                    block.powerupPrefab = 
                        spawnablePowerups[Random.Range(0, spawnablePowerups.Length)];
                }
            }
        }
        CountBreakableBlocks();
    }


}
