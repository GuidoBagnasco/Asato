using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Characters.FirstPerson;

public class WeaponSelector : Singleton<WeaponSelector> {

	public List<Weapon> weapons = new List<Weapon>();
	private int current = 0;
	private float sensibility = 1.0f;
	private bool smoothOn = false;
	private bool changing = false;


	public void AddWeapon (Weapon w) {
		weapons.Add (w);
	}


	public void ChangeWeapons (float d) {
		if (Mathf.Abs (d) > sensibility) {
			if (!smoothOn && !changing) {
				StartCoroutine (SmoothChange (d));
			}
		}
		else {
			StopCoroutine (SmoothChange (d));
			smoothOn = false;
		}
	}


	public Weapon GetCurrent () {
		return weapons [current];
	}


	private void ChangeWeapon (float d) {
		weapons[current].Sheathe (false);
		if (d > sensibility)
			current = (++current) < weapons.Count ? current : 0;
		else if (d < -sensibility)
			current = (--current) >= 0 ? current : weapons.Count - 1;
		weapons[current].Sheathe (true);
	}


	private IEnumerator SmoothChange (float d) {
		smoothOn = changing = true;
		while (smoothOn) {
			ChangeWeapon (d);
			yield return new WaitForSeconds (1f);
		}
		changing = false;
	}
}
