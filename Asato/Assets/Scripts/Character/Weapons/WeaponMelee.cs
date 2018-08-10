using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponMelee : Weapon {

	protected ANIM animations;
	public Animator anim;


	protected override void OnAwake () {
		type = WeaponType.Melee;
	}


	public override void Attack () {
		PlayAnim (ANIM.Attack);
        (AudioSourcePlayer.Instance as AudioSourcePlayer).PlayOneShot(attackSound);
		OnAttack ();
	}

	protected virtual void OnAttack () { }


	protected void PlayAnim (ANIM a) {
		switch (a) {
			case ANIM.Attack:
				anim.SetTrigger ("Attack");
				break;
		}
	}
}
