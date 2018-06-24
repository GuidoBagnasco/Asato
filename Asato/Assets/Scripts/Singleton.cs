using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour {

	public static Singleton<T> Instance = null;


	private void Awake () {
		if (Instance == null)
			Instance = this;
		else if (Instance != this)
			DestroyImmediate (gameObject);

		OnAwake ();
	}
	
	protected virtual void OnAwake () {	}

}
