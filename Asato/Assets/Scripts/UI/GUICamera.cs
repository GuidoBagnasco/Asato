using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Camera ) )]
public sealed class GUICamera : MonoBehaviour
{
	public static Camera getCamera { get; private set; }
	public static Transform getTransform { get; private set; }


	void Awake () {
		getTransform = transform;
		getCamera = GetComponent<Camera>();
	}                 


	public static Vector3 ScreenToWorldPoint (Vector2 position) {
		return getCamera.ScreenToWorldPoint(position);
	}
};
