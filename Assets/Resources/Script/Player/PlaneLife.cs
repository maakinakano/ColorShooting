using UnityEngine;
using System.Collections;

public class PlaneLife : MonoBehaviour {
    public float maxHp;
    private float hp;

    void Start() {
        hp = maxHp;
    }

    public void Damage(float damage) {
        hp -= damage;
    }
}
