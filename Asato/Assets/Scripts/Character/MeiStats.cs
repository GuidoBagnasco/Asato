﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeiStats : Singleton<MeiStats>
{

    public Health health;
    private AudioSourcePlayer aSource;
    public AudioClip pickUp;
    public WeaponRange gun;
    private int score = 0;


	private void Start()
	{
        aSource = AudioSourcePlayer.Instance as AudioSourcePlayer;
	}

	public void Restore()
    {
        health.Damage(-80);
        gun.VaryAmmo(70);
    }


    public void AddScore(int s)
    {
        score += s;
        (HUD.Instance as HUD).UpdateElement(HUD.ElementType.SCORE, score);
    }


    public int GetScore()
    {
        return score;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Loot")
        {
            aSource.PlayOneShot (pickUp);
            Restore();
            other.GetComponent<Collider>().enabled = false;
            foreach (Renderer r in other.GetComponentsInChildren(typeof(Renderer)))
            {
                r.enabled = false;
            }
        }
    }
}