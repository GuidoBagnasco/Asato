using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mei : MonoBehaviour {

	private InputManager iManager = null;
	private Transform cam = null;
	private Rigidbody rBody = null;
	public GameObject arm;
	float angle  = 0f;

	private bool isGrounded = true;
	public float groundSearchRange = 5.0f;
	private int layerMask = 1 << 10 | 1 << 11;



	private void Start () {
		iManager = InputManager.Instance as InputManager;
		cam = Camera.main.transform;
		rBody = GetComponent<Rigidbody> ();
	}
	

	void Update () {
        if (GameController.Over) this.enabled = false;
		Rotate ();
		Move ();
		Jump ();
		ChangeWeapon ();
		Attack ();
	}

	//--------------------------------------------------------------------------//

	public float minimumY = -90f;
	public float maximumY = 60f;
	private float sensitivity = 130f;

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
		if (iManager.Attack ()) {
			if (InputMobile.AutoAttack)
				(WeaponSelector.Instance as WeaponSelector).GetCurrent ().AutoAim ();
			else
				(WeaponSelector.Instance as WeaponSelector).GetCurrent ().Attack ();
		}
	}

	//--------------------------------------------------------------------------//

	private float jumpForce = 2.5f;

	private void Jump () {
		RaycastHit hit;
		if (isGrounded) {
			if (!Physics.Raycast (transform.position, transform.TransformDirection (Vector3.down), out hit, groundSearchRange, layerMask)) {
				rBody.AddForce (jumpForce * Vector3.up, ForceMode.Impulse);
				isGrounded = false;
			}
		} else {
			isGrounded = Physics.Raycast (transform.position + Vector3.forward * 2f, transform.TransformDirection (Vector3.down), out hit, groundSearchRange, layerMask);
		}
	}

}
