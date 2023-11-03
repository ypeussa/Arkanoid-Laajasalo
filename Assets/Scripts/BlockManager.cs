using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {
    public int nx = 5;
    public float dx = 2f;
    public int ny = 4;
    public float dy = 1f;

    public GameObject normalBlockPrefab;
    public Transform blocksFolder;

    void Start() {
        //var newBlock = Instantiate(normalBlockPrefab);
        //newBlock.transform.position = transform.position;
        var c = transform.position;

        for (int j = 0; j < ny; j++) {
            for (int i = 0; i < nx; i++) {
                var go = Instantiate(normalBlockPrefab);
                float x0 = (nx - 1) * 0.5f * dx;
                float newX = c.x - x0 + i * dx;
                go.transform.position = new Vector2(newX, c.y);
                go.transform.parent = blocksFolder;
            }
        }
    }


}
