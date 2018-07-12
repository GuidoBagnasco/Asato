using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;

public class InputKeyboard : MonoBehaviour, IInput {

	private MouseLook m_MouseLook;
	public float XSensitivity = 2.3f;
	public float YSensitivity = 2.3f;


	public bool Attack () {
		return CrossPlatformInputManager.GetButtonDown ("Attack");
	}


	public Vector2 Move () {
		float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
		float vertical = CrossPlatformInputManager.GetAxis("Vertical");
		return new Vector2 (horizontal, vertical).normalized;
	}


	public Vector2 Rotate () {
		float yRot = CrossPlatformInputManager.GetAxis("Mouse Y") * -YSensitivity;
		float xRot = CrossPlatformInputManager.GetAxis("Mouse X") * -XSensitivity;
		return new Vector2 (-xRot, yRot);
	}


	public float ChangeWeapon () {
		return CrossPlatformInputManager.GetAxis("Mouse ScrollWheel");
	}
}
