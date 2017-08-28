using UnityEngine;
using System.Collections;

public class PlaneShoot : MonoBehaviour {

    private bool shootF;
    public float timeSpan;
    public GameObject bullet;
    private float timeTillShoot;
    // Use this for initialization
    void Start() {
        shootF = true;
        timeTillShoot = timeSpan*3;
    }

    // Update is called once per frame
    void Update() {
        if (shootF) {
            timeTillShoot -= Time.deltaTime;
            if(timeTillShoot <= 0F) {
                timeTillShoot += timeSpan;
                Vector3 pos = transform.position;
                pos.x -= 25F;
                Instantiate(bullet, pos, Quaternion.identity);
                pos.x += 50F;
                Instantiate(bullet, pos, Quaternion.identity);
            }
        }
    }
}
