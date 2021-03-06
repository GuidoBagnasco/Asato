﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeiStats : Singleton<MeiStats> {

    public Health health;
    public WeaponRange gun;
    private int score = 0;



	public void Restore () {
        health.Damage (-80);
        gun.VaryAmmo (70);
    }


    public void AddScore (int s) {
        score += s;
		(HUD.Instance as HUD).UpdateElement (HUD.ElementType.SCORE, score);
    }


    public int GetScore() {
        return score;
    }
}
