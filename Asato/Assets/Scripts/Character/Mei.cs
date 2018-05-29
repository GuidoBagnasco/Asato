using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mei : MonoBehaviour {


	private InputManager iManager = null;
	private Transform cam = null;
	private Rigidbody rBody = null;
	float angle  = 0f;

	private void Start () {
		iManager = InputManager.Instance as InputManager;
		cam = Camera.main.transform;
		rBody = GetComponent<Rigidbody> ();
		//minimumY = minimumY * Mathf.Deg2Rad;
		//maximumY = maximumY * Mathf.Deg2Rad;

	}
	

	void Update () {
		Rotate ();
		Move ();
		Jump ();
		ChangeWeapon ();
		Attack ();
	}

	//--------------------------------------------------------------------------//

	public float minimumY = -60f;
	public float maximumY = 60f;
	private float sensitivity = 130F;

	private void Rotate () {
		Vector2 rot = iManager.Rotate ();
		angle += -rot.y * sensitivity * Time.deltaTime;
		angle = Mathf.Clamp (angle, minimumY, maximumY);
		transform.Rotate(rot.x * sensitivity * Vector3.up * Time.deltaTime, Space.World);
		cam.transform.localEulerAngles = angle * Vector3.right;
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
