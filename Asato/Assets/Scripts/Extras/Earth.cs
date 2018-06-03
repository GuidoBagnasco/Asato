using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MonoBehaviour {

	private float rotSpeed = 4.0f;


	private void FixedUpdate () {
		transform.Rotate (-transform.right - transform.up * 0.01f, rotSpeed * Time.deltaTime);
	}
}
