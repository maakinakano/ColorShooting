using UnityEngine;
using System.Collections;

public abstract class AbstractEnemyMove : MonoBehaviour {

    public float speed;
    public MoveMode mode;

    void Update() {
        Move();
        Vector2 pos = transform.position;
        float temp = pos.x;
        pos.x = Mathf.Clamp(temp, -Settings.WIDTH, Settings.WIDTH);
        if (pos.x != temp) {
            XLimit();
        }
        transform.position = pos;
    }

    public abstract void Move();
    public abstract void XLimit();
}

public enum MoveMode {
    RIGHT,
    LEFT,
    DOWN,
    UP,
}
