using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public Health health;
    public WeaponRange gun;
    private int score = 0;
    public static PlayerStats Instance;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) DestroyImmediate(this);
    }


    public void restore()
    {
        health.addlife();
        gun.ammo += 70;
    }
    public void AddScore (int s)
    {
        score += s;
        HUD.Instance.UpdateText(HUD.TextType.SCORE, score);
    }


    public int GetScore()
    {
        return score;
    }
}
