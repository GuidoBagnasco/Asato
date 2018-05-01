using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

	public float dmg = 0f;

	protected enum ANIM {
		Attack = 1
	};


	private void Start () {
		#if UNITY_EDITOR
		if (dmg == 0)
			Debug.LogWarning ("Weapon`s damage not set");
		#endif
	}

	public abstract void Attack ();

	public void Sheathe(bool show) {
		gameObject.SetActive (show);
	}

}
