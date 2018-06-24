using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

	private UnityEngine.UI.Image aimImage;
	public UnityEngine.UI.Image flowerImage;
	public Sprite[] designs;
	private AimManager aimManager;

	private bool filling = false;



	private void Awake () {
		aimImage = GetComponent<UnityEngine.UI.Image> ();
		//flowerImage = gameObject.GetComponentInChildren<UnityEngine.UI.Image> ();
	}


	private void Start () {
		aimManager = AimManager.Instance as AimManager;
	}


	private void Update () {
		SetDesign ();
		#if !UNITY_IOS || UNITY_ANDROID
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
			flowerImage.fillAmount = 0.0f;
			StopCoroutine (FillFlower ());
		}
	}


	private IEnumerator FillFlower () {
		filling = true;
		flowerImage.fillAmount = 0.0f;
		do {
			flowerImage.fillAmount = Mathf.Clamp01 (flowerImage.fillAmount + aimManager.Speed ());
			yield return new WaitForSeconds (Time.deltaTime);
			print (flowerImage.fillAmount);
		} while (flowerImage.fillAmount < 1f);
		filling = false;
	}
}
