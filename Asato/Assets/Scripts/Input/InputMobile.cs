using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputMobile : MonoBehaviour, IInput {

	private MobileControlsRef joyCon = null;
	public static bool AutoAttack = false;


	private void Start() {
		AutoAttack = true;
		joyCon = MobileControlsRef.Instance as MobileControlsRef;
	}


	public bool Attack() {
		return true;
	}


	public Vector2 Move () {
		return joyCon.movStick.padPos;
	}


	public Vector2 Rotate () {
		return joyCon.rotStick.padPos;
	}


	public float ChangeWeapon () {
		return joyCon.chwStick.padPos.x;
	}


	public bool Jump () {
		return false;
	}

}
