using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletMove : MonoBehaviour {

    public float speed;
    public float damage;

    void Start() {
        GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.8f);
        GetComponent<Rigidbody2D>().velocity = speed * Vector2.up;
    }

    void Update () {
        if (transform.position.y > Settings.UP_LIMIT ||
            transform.position.x > Settings.WIDTH + 50||
            transform.position.x < -Settings.WIDTH - 50)
            GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        EnemyLife life = other.gameObject.GetComponent<EnemyLife>();
        if (life != null) {
            GameObject.Destroy(gameObject);
            life.Damage(EnemyLife.RED, damage);
        }
    }
}
