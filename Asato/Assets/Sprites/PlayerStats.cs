using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Singleton<PlayerStats> {

    public Health health;
    public WeaponRange gun;
    private int score = 0;


    public void restore () {
        health.addlife();
        gun.VaryAmmo(70);
        Debug.Log("InRestore");
    }


    public void AddScore (int s) {
        score += s;
		(HUD.Instance as HUD).UpdateText(HUD.TextType.SCORE, score);
    }


    public int GetScore() {
        return score;
    }
}
