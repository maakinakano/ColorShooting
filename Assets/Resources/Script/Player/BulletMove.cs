using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMove : MonoBehaviour {

    public float speed;

    void Start() {
        GetComponent<Rigidbody2D>().velocity = speed * Vector2.up;
    }

    void Update () {
        if (transform.position.y > Settings.UP_LIMIT ||
            transform.position.x > Settings.WIDTH + 50||
            transform.position.x < -Settings.WIDTH - 50)
            GameObject.Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        GameObject.Destroy(gameObject);
        EnemyLife life = other.gameObject.GetComponent<EnemyLife>();
        if (life != null) {
            life.Damage(EnemyLife.RED, 10F);
        }
    }
}
