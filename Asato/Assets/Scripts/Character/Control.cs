using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Control : FirstPersonController {


	protected override void Attack () {
		WeaponSelector.Instance.GetCurrent ().Attack ();
	}

	protected override void ChangeWeapon () {
		WeaponSelector.Instance.ChangeWeapons ();
	}
}
