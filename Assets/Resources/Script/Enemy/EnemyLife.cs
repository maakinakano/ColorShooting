using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyLife : MonoBehaviour {

    public static int RED = 0;
    public static int GREEN = 1;
    public static int BLUE = 2;
    public static int[] DAMAGE_COLORS = { RED, GREEN, BLUE };
    public float[] max = new float[3];
    private float[] hp = new float[3];
    SpriteRenderer sr;

    void Start () {
        sr = GetComponent<SpriteRenderer>();
        foreach (int c in DAMAGE_COLORS)
            hp[c] = max[c];
        ColorChange();
    }

    public void Damage(int dc, float damage) {
        //Damge
        hp[dc] -= damage;
        if (hp[dc] < max[dc]/50)
            hp[dc] = 0;

        //ColorChange
        ColorChange();

        //Dead
        bool tempF = true;
        foreach (int c in DAMAGE_COLORS) tempF &= hp[c] <= 0F;
        if (tempF) GameObject.Destroy(gameObject);
    }

    public void ColorChange() {
        float changeR = 1F, changeG = 1F, changeB = 1F;
        if (hp[GREEN] <= 0F && hp[BLUE] <= 0F) {
            changeG = changeB = 1F - hp[RED] / max[RED];
        }
        sr.color = new Color(changeR, changeG, changeB, 1.0f);
    }
}
