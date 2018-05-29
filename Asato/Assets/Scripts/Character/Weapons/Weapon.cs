using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

	public int dmg = 0;
	public int range = 5;
	private float fireRate = 0.8f;

	private bool aiming = false;
	private bool attacking = false;
    
	protected enum ANIM {
		Attack = 1
	};


	private void Start () {
		#if UNITY_EDITOR
		if (dmg == 0)
			Debug.LogWarning ("Weapon`s damage not set");
        #endif

        OnStart ();
	}


	protected virtual void OnStart() { }


	public void Sheathe(bool show) {
		gameObject.SetActive (show);
	}


	public abstract void Attack ();


	public void AutoAim () {
		RaycastHit hit;
		aiming = Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out hit, range, 1 << 8);
		if (aiming && !attacking) 
			StartCoroutine (AutoAttack ());
	}


	private IEnumerator AutoAttack () {
		attacking = true;
		while (aiming) {
			yield return new WaitForSeconds (fireRate);
			Attack ();
		}

		attacking = false;
		StopCoroutine (AutoAttack ());
	}
}
