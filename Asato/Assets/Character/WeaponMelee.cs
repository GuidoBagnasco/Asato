using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class WeaponMelee : Weapon {

	public float dmg = 0f;

	protected enum ANIM {
		Attack = 1
	};

	protected ANIM animations;
	public Animator anim;



	private void Start () {
#if UNITY_EDITOR
		if (dmg == 0)
			Debug.LogWarning ("Weapon`s damage not set");
#endif
	}


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
