using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMove : MonoBehaviour {

    private float speed;
    private float direction;
    private bool push;

    void Start () {
        speed = 300F;
        push = false;
	}
	
	void Update () {
        if (push) {
            Vector2 pos = transform.position;
            pos += direction * speed * Time.deltaTime * Vector2.right;
            pos.x = Mathf.Clamp(pos.x, -Settings.WIDTH, Settings.WIDTH);
            transform.position = pos;
        }
    }

    public void OnPointerDown(float direction) {
        this.direction = direction;
        push = true;
    }

    public void OnPointerUp() {
        direction = 0F;
        push = false;
    }
}

