using UnityEngine;
using System.Collections;

public class EnemyShoot1 : MonoBehaviour {

    public float timeSpan;
    public GameObject bullet;
    private float timeTillShoot;
    public float speed;
    public Vector2 direction;
    public float damage;

    // Use this for initialization
    void Start() {
        timeTillShoot = timeSpan;
    }

    // Update is called once per frame
    void Update() {
        timeTillShoot -= Time.deltaTime;
        if (timeTillShoot <= 0F) { 
            timeTillShoot += timeSpan;
            Vector3 pos = transform.position;
            pos.z = 1;
            GameObject spawnBullet = Instantiate(bullet, pos, Quaternion.identity);
            AbstractEnemyBullet aeb = spawnBullet.GetComponent<AbstractEnemyBullet>();
            aeb.speed = this.speed;
            aeb.direction = this.direction;
            aeb.damage = this.damage;
        }
    }
}
