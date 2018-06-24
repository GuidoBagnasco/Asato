using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

	private UnityEngine.UI.Image aimImage;
	private UnityEngine.UI.Image flowerImage;
	public Sprite[] designs;
	private AimManager aimManager;

	private bool filling = false;



	private void Awake () {
		aimImage = GetComponent<UnityEngine.UI.Image> ();
		flowerImage = GetComponentInChildren<UnityEngine.UI.Image> ();
	}


	private void Start () {
		aimManager = AimManager.Instance as AimManager;
	}


	private void Update () {
		SetDesign ();
		#if UNITY_STANDALONE
		CheckLock ();
		#endif
	}


	private void SetDesign () {
		aimImage.sprite = designs [(int)aimManager.GetCurrentType ()];
	}


	private void CheckLock () {
		if (!filling && aimManager.IsLocked ()) {
			StartCoroutine (FillFlower ());
		} else {
			StopCoroutine (FillFlower ());
			filling = false;
		}
	}


	private IEnumerator FillFlower () {
		yield return new WaitForFixedUpdate ();
		filling = true;
		flowerImage.fillAmount = 0.0f;
		do {
			flowerImage.fillAmount = Mathf.Clamp01 (flowerImage.fillAmount + aimManager.Speed () * Time.fixedDeltaTime);
		} while (flowerImage.fillAmount < 1.0f);
		filling = false;
	}
}
