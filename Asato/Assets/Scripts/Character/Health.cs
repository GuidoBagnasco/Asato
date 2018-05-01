using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	private static float HEALTH_MAX = 100.0f;
	private float health = HEALTH_MAX;


	public void Damage (int amount) {
		health = Mathf.Clamp (health - amount, 0.0f, HEALTH_MAX);
	}

}
