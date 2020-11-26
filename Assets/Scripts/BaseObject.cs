using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    List<Transform> tiles = new List<Transform>();

    void OnValidate() {
        GetTiles();
    }

    void Awake() {
        GetTiles();
    }

    void GetTiles() {
        tiles.Clear();
        foreach (Transform child in transform) {
            if (child.CompareTag("Tile")) {
                tiles.Add(child);
            }
        }
    }
}
