﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

	public int dmg = 0;
	public int range = 5;
	private float fireRate = 0.8f;

	private bool locked = false;
	private bool attacking = false;
    
	protected enum ANIM {
		Attack = 1
	};


	public enum WeaponType {
		Melee = 0,
		Range = 1
	};

	public WeaponType type;


	private void Awake () {
		OnAwake ();
	}
		
	protected abstract void OnAwake ();


	private void Start () {
		#if UNITY_EDITOR
		if (dmg == 0)
			Debug.LogWarning ("Weapon`s damage not set");
        #endif

        OnStart ();
	}


	protected virtual void OnStart() { }


    private void Update() {
        RaycastHit hit;
        locked = Physics.Raycast(transform.position, transform.parent.forward, out hit, range, 1 << 8);
    }


	public void Sheathe (bool show) {
		gameObject.SetActive (show);
	}


	public abstract void Attack ();


	public void AutoAim () {
		if (locked && !attacking) StartCoroutine (AutoAttack ());
	}


	public bool IsLocked () { return locked; }


	private IEnumerator AutoAttack () {
		attacking = true;
        (AimManager.Instance as AimManager).StartFilling ();
		while (locked) {
			yield return new WaitForSeconds (fireRate);
			Attack ();
		}

		attacking = false;
		(AimManager.Instance as AimManager).EndFilling();
        StopCoroutine (AutoAttack ());
	}


	public float getFireRate () { return fireRate; }

}
