﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRange : Weapon {

	protected ANIM animations;
	public Animator anim;
    public ParticleSystem bullets;
    [HideInInspector]
    public int ammo = 100;
    private bool isPlaying = false;



	protected override void OnAwake () {
		type = WeaponType.Range;
	}


    public override void Attack () {
		if (isPlaying || ammo == 0) return;
        (AudioSourcePlayer.Instance as AudioSourcePlayer).PlayOneShot(attackSound);
		PlayAnim (ANIM.Attack);

        if (VaryAmmo(-1))
            OnAttack();
	}


	protected virtual void OnAttack () {
        bullets.Emit (1);
	}


    public void Stopped () {
        isPlaying = false;
    }


	protected void PlayAnim (ANIM a) {
		switch (a) {
			case ANIM.Attack:
				anim.SetTrigger ("Shoot");
				break;
		}
	}


	public bool VaryAmmo (int amount) {
        ammo += amount;
		(HUD.Instance as HUD).UpdateElement (HUD.ElementType.AMMO, ammo);

		return ammo > 0;
	}
}
