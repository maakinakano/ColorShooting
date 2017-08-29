using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class AbstractEnemyBullet : MonoBehaviour {

    protected Rigidbody2D r2d;
    [HideInInspector]
    public float damage;
    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public float speed;

    void Start() {
        r2d = GetComponent<Rigidbody2D>();
        SetStart();
    }

    void Update() {
        if (transform.position.y > Settings.UP_LIMIT ||
            transform.position.y < Settings.DOWN_LIMIT-100 ||
            transform.position.x > Settings.WIDTH + 50 ||
            transform.position.x < -Settings.WIDTH - 50)
            GameObject.Destroy(gameObject);
    }

    public abstract void SetStart();

    private void OnTriggerEnter2D(Collider2D other) {
        PlaneLife life = other.gameObject.GetComponent<PlaneLife>();
        if (life != null) {
            GameObject.Destroy(gameObject);
            life.Damage(damage);
        }
    }
}
