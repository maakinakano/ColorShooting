using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMoveScript : MonoBehaviour {

    private float speed;
    private float direction;
    private bool push;
    private Rigidbody2D r2d;
    private static float WIDTH = 450F;

    void Start () {
        speed = 300F;
        push = false;
        r2d = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (push) {
            Vector2 pos = transform.position;
            pos += direction * speed * Time.deltaTime * Vector2.right;
            pos.x = Mathf.Clamp(pos.x, -WIDTH, WIDTH);
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

