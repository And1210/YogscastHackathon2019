using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed;

    Camera mainCamera;

    // Start is called before the first frame update
    void Start() {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update() {
        Vector3 input = GetInput();
        Vector3 pos = UpdatePosition(input);

        mainCamera.transform.position = new Vector3(pos.x, pos.y, -10);
    }

    Vector3 GetInput() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        return new Vector3(horizontal, vertical, 0);
    }

    Vector3 UpdatePosition(Vector3 input) {
        Vector3 pos = transform.position;
        GetComponent<Rigidbody2D>().MovePosition(new Vector3(pos.x+input.x*speed*Time.deltaTime, 
                                    pos.y+input.y*speed*Time.deltaTime, 0));
        // transform.position += input * speed * Time.deltaTime;
        return transform.position;
    }
}
