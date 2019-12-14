using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject dirtPrefab;   //The dirt object to be spawned
    private GameObject[] dirtList;  //The list of dirt objects

    public Canvas HUD;  //A reference to the overarching canvas object
    public Sprite selected; //The sprite of an item selected
    public Sprite idle; //The sprite of an item not selected
    private GameObject slotSelected;    //A reference to the current selected slot
    private int slotNum;    //The number of the current slot we are on
    //0 - hand, 1 - seed, 2 - watering can

    public string[] names = new string[5];
    private bool[] discovered = {true, false, false, false, false};

    void Start() {
        //Adding dirt to the map to be tilled
        List<GameObject> temp = new List<GameObject>();
        for (float x = -9.5f; x <= -0.5f; x++) {
            for (int k = 0; k < 6; k++) {
                for (float y = 7.5f-3*k; y >= 6.5f-3*k; y--) {
                    temp.Add(Instantiate(dirtPrefab, new Vector3(x, y, 0), Quaternion.identity));
                }
            }
        }
        dirtList = temp.ToArray();
        
        //Setting up inventory selection
        slotNum = 0;
        slotSelected = HUD.transform.Find("Slot1").gameObject;
        ChangeSelected(slotNum);
        Discover(0);
    }

    // Update is called once per frame
    void Update() {
        
    }

    //Changes the inventory slot that is selected
    public void ChangeSelected(int index) {
        if (index < discovered.Length) {
            if (!discovered[index])
                return;
        } else 
            return;

        GameObject temp = HUD.transform.Find("Slot"+(index+1)).gameObject;
        if (temp == null) 
            return;
        
        slotNum = index;
        slotSelected.GetComponent<Image>().sprite = idle;

        slotSelected = temp;
        slotSelected.GetComponent<Image>().sprite = selected;
    }

    public void Discover(int index) {
        if (index >= discovered.Length) {
            return;
        }

        discovered[index] = true;

        GameObject temp = HUD.transform.Find("Slot"+(index+1)).transform.Find("Item").gameObject;
        Color tempColor = temp.GetComponent<Image>().color;
        tempColor.a = 1f;
        temp.GetComponent<Image>().color = tempColor;
        // temp.GetComponent<Image>().CrossFadeAlpha(0f, 1f, false);
    }

    public int GetSlot() {
        return slotNum;
    }

}
