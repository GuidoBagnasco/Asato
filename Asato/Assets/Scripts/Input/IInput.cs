using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput {

	bool Attack ();

	Vector2 Move ();

	Vector2 Rotate ();

	float ChangeWeapon ();

}
