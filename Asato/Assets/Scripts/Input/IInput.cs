using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput {

	bool Attack ();

	Vector2 Walk ();

	Vector2 Rotate ();

	bool Jump ();

	int ChangeWeapon ();

}
