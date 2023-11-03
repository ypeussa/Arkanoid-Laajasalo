using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentDataStore : MonoBehaviour {
    public int highScore;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
