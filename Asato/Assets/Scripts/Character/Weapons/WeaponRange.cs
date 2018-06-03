using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRange : Weapon {

	protected ANIM animations;
	public Animator anim;
    protected ParticleSystem _balaE;
    [HideInInspector]
    public int ammo = 100;
    private bool isPlaying = false;


    protected override void OnStart()
    {
        _balaE = GetComponentInChildren<ParticleSystem>();
    }

    public override void Attack () {
        if (isPlaying) return;

		PlayAnim (ANIM.Attack);

		if (VaryAmmo (-1))
			OnAttack ();
	}


	protected virtual void OnAttack () {
        _balaE.Emit(1);
	}


    public void Stopped() {
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
        HUD.Instance.UpdateText(HUD.TextType.AMMO, ammo);
		return ammo > 0;
	}
}
