using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour {

	public int dmg = 0;
    
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

	public abstract void Attack ();

	public void Sheathe(bool show) {
		gameObject.SetActive (show);
	}

    protected virtual void OnStart()
    {

    }

}
