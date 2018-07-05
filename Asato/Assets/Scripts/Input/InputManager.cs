using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager> {

	public IInput input;
	public GameObject mobileControls;


	protected override void OnAwake () {
#if false//UNITY_STANDALONE || UNITY_EDITOR
		input = gameObject.AddComponent<InputKeyboard>();
        ShowPointer (false);
#else
		input = gameObject.AddComponent<InputMobile>();
		Instantiate(mobileControls);
#endif
	}


	public bool Attack () { return input.Attack (); }

	public Vector2 Move () { return input.Move (); }

	public Vector2 Rotate () { return input.Rotate (); }

	public float ChangeWeapon () { return input.ChangeWeapon (); }

    public void ShowPointer (bool b) {
        Cursor.visible = b;
        Cursor.lockState = b ? CursorLockMode.None : CursorLockMode.Locked;

    }
}
