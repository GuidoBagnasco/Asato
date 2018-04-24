using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class WeaponMelee : Weapon {

	protected ANIM animations;
	public Animator anim;




	public override void Attack () {
		PlayAnim (ANIM.Attack);
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
