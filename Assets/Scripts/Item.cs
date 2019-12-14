using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType {Seed, Watering_Can};

public class Item : MonoBehaviour {

    public ItemType item;

    private GameObject gameManager;
    private GameManager gameManagerScript;

    void Start() {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    void OnMouseDown() {
        gameManagerScript.Discover(GetIndex(item));

        Destroy(gameObject);
    }

    int GetIndex(ItemType item) {
        switch(item) {
            case ItemType.Seed:
                return 1;
            case ItemType.Watering_Can:
                return 2;
            default: 
                return 0;
        }
    }
}
