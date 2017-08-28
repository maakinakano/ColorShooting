using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEnemyMove : AbstractEnemyMove {

    private Vector2 direction;
    private MoveMode nextMode;
    public float downLength;
    private float downGoal;

    public override void Move() {
        switch(mode) {
            case MoveMode.RIGHT:
                direction = Vector2.right;
                break;
            case MoveMode.LEFT:
                direction = Vector2.left;
                break;
            case MoveMode.DOWN:
                direction = Vector2.down;
                break;
            default:
                direction = Vector2.zero;
                break;
        }
        Vector2 pos = transform.position;
        pos += direction * speed * Time.deltaTime;
        if (mode == MoveMode.DOWN) {
            float temp = pos.y;
            pos.y = Mathf.Clamp(pos.y, downGoal, Settings.UP_LIMIT);
            if (temp != pos.y)
                mode = nextMode;
        }
        transform.position = pos;

        }

    public override void XLimit() {
        switch(mode) {
            case MoveMode.RIGHT:
                mode = MoveMode.DOWN;
                nextMode = MoveMode.LEFT;
                downGoal = transform.position.y - downLength;
                break;
            case MoveMode.LEFT:
                mode = MoveMode.DOWN;
                nextMode = MoveMode.RIGHT;
                downGoal = transform.position.y - downLength;
                break;
        }
        if (downGoal < Settings.MAX_DOWN)
            downGoal = Settings.MAX_DOWN;
    }

}
