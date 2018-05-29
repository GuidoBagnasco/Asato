using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mei : MonoBehaviour {


	private InputManager iManager = null;
	private Transform cam = null;
	private Rigidbody rBody = null;


	private void Start () {
		iManager = InputManager.Instance as InputManager;
		cam = Camera.main.transform;
		rBody = GetComponent<Rigidbody> ();
	}
	

	void Update () {
		Rotate ();
		Move ();
		Jump ();
		ChangeWeapon ();
		Attack ();
	}

	//--------------------------------------------------------------------------//

	private const float minimumY = -60f;
	private const float maximumY = 60f;
	private float sensitivity = 130F;

	private void Rotate () {
		Vector2 rot = iManager.Rotate ();
		cam.transform.Rotate(-rot.y * sensitivity * Vector3.right * Time.deltaTime);
		//cam.transform.localEulerAngles = new Vector3(Mathf.Clamp(cam.transform.localEulerAngles.x, minimumY, maximumY), 0, 0);
		transform.Rotate(rot.x * sensitivity * Vector3.up * Time.deltaTime, Space.World);
	}

	//--------------------------------------------------------------------------//

	private float moveSpeed = 15f;

	private void Move () {
		Vector2 mov = iManager.Move ();
		transform.Translate (new Vector3 (mov.x, 0, mov.y) * moveSpeed * Time.deltaTime);
	}

	//--------------------------------------------------------------------------//

	private void ChangeWeapon () {
		(WeaponSelector.Instance as WeaponSelector).ChangeWeapons(iManager.ChangeWeapon ());
	}

	//--------------------------------------------------------------------------//

	private void Attack () {
		if (InputMobile.AutoAttack)
			(WeaponSelector.Instance as WeaponSelector).GetCurrent().AutoAim();
		else if (iManager.Attack ())
			(WeaponSelector.Instance as WeaponSelector).GetCurrent().Attack();
	}

	//--------------------------------------------------------------------------//

	private float jumpForce = 1000f;

	private void Jump () {
		if (iManager.Jump ())
			rBody.AddForce (jumpForce * Vector3.forward);
		//if (iManager.Jump ())
		//	transform.Translate(Physics.gravity * m_GravityMultiplier * Time.fixedDeltaTime);
		//	GetComponent<Rigidbody> ().velocity = Vector3.up * 4444f;
		//if (true) {
		//	float jumpForce = -m_StickToGroundForce;
		//
		//	if (m_Jump)
		//	{
		//		m_MoveDir.y = m_JumpSpeed;
		//		PlayJumpSound();
		//		m_Jump = false;
		//		m_Jumping = true;
		//	}
		//}
		//else
		//{
		//	m_MoveDir += Physics.gravity*m_GravityMultiplier*Time.fixedDeltaTime;
		//}
	}

	//--------------------------------------------------------------------------//

}
