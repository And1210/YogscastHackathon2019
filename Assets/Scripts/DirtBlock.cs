using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtBlock : MonoBehaviour {

    public Sprite[] stages = new Sprite[3];     //The 3 sprites for the 3 stages

    public float GrowDelay;   //The delay between each stage of growing in seconds

    private GameObject child;   //The child object of the dirt prefab, has the plant sprite
    private SpriteRenderer sr;  //The sprite renderer of the child
    private int stageNum = 0;   //The current stage the plant is on

    private float Timer;    //A timer to be used to switch stages
    private float StartTime;
    private bool active;

    private GameObject gameManager;
    private GameManager gameManagerScript;

    void Start() {
        gameManager = GameObject.Find("GameManager");
        gameManagerScript = gameManager.GetComponent<GameManager>();

        child = gameObject.transform.GetChild(0).gameObject;
        sr = child.GetComponent<SpriteRenderer>();

        Timer = 0f;
        StartTime = 0f;
        active = false;
    }

    void Update() {
        Timer += Time.deltaTime;

        if (active) {
            if ((Timer-StartTime) > (stageNum + 1)*GrowDelay) {
                stageNum++;
                stageNum = Mathf.Min(stageNum, stages.Length - 1);
                sr.sprite = stages[stageNum];
            }
        }
    }

    void InitStages() {
        sr.sprite = stages[stageNum];

        active = true;
        StartTime = Timer;
    }

    void OnMouseDown() {
        if (gameManagerScript.GetSlot() == 1) {
            InitStages();
        }
    }
}
