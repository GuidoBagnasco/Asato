using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeiStats : MonoBehaviour {

    public Health health;
    public WeaponRange gun;
    private int score = 0;
    public static MeiStats Instance;


    private void Awake() {
        if (Instance == null) Instance = this;
        else if (Instance != this) DestroyImmediate(this);
    }


    public void restore() {
        health.addlife();
        gun.VaryAmmo(70);
        Debug.Log("InRestore");
    }


    public void AddScore (int s) {
        score += s;
			(HUD.Instance as HUD).UpdateText(HUD.TextType.SCORE, score);
    }


    public int GetScore()
    {
        return score;
    }
}
