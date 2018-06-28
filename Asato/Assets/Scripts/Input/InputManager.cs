using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager> {

	public IInput input;
	public GameObject mobileControls;


	protected override void OnAwake () {
#if UNITY_STANDALONE || UNITY_EDITOR
		input = gameObject.AddComponent<InputKeyboard>();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
#else
		input = gameObject.AddComponent<InputMobile>();
		Instantiate(mobileControls);
#endif
	}


	public bool Attack () { return input.Attack (); }

	public Vector2 Move () { return input.Move (); }

	public Vector2 Rotate () { return input.Rotate (); }

	public float ChangeWeapon () { return input.ChangeWeapon (); }

    public void ShowPointer() {
#if UNITY_STANDALONE || UNITY_EDITOR
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
#endif
    }
}
