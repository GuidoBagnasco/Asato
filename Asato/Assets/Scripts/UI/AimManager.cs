using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimManager : Singleton<AimManager> {

	private WeaponSelector wSelector;
    public Aim aim;


	private void Start () {
		wSelector = WeaponSelector.Instance as WeaponSelector;
	}
	

	public Weapon.WeaponType GetCurrentType () { return wSelector.GetCurrent ().type; }


	public bool IsLocked () { return wSelector.GetCurrent ().IsLocked (); }


	public float Speed () { return wSelector.GetCurrent ().getFireRate (); }


    public void StartFilling() { aim.StartCoroutine (aim.Fill ()); }


    public void EndFilling() { aim.EndFill (); }

}
