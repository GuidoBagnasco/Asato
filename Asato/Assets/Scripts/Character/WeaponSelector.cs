using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Characters.FirstPerson;

public class WeaponSelector : MonoBehaviour {

	public List<Weapon> weapons = new List<Weapon>();
	private int current = 0;
	public static WeaponSelector Instance = null;


	private void Awake () {
		if (!Instance)
			Instance = this;
		else if (Instance != this)
			DestroyImmediate (this);
	}


	public void AddWeapon (Weapon w) {
		weapons.Add (w);
	}


	public void ChangeWeapons () {
		weapons[current].Sheathe (false);
		current = (++current) < weapons.Count ? current : 0;
		weapons[current].Sheathe (true);

	}

	public Weapon GetCurrent () {
		return weapons [current];
	}
}
