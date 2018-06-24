﻿using System.Collections;
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
	}


	private void SetDesign () {
		aimImage.sprite = designs [(int)aimManager.GetCurrentType ()];
	}


	private void FillFlower () {
        if (flowerImage.fillAmount >= 1f) ResetFillAmount ();
        flowerImage.fillAmount = Mathf.Clamp01 (flowerImage.fillAmount + aimManager.Speed () * Time.smoothDeltaTime);
		print (flowerImage.fillAmount);
	}


    public IEnumerator Fill () {
        float animationTime = 0.0f;
        filling = true;
        do {
            animationTime = Mathf.Clamp01 (animationTime + Time.deltaTime);
            flowerImage.fillAmount = animationTime / aimManager.Speed();
            yield return new WaitForEndOfFrame ();
            if (animationTime >= aimManager.Speed()) animationTime = 0.0f;
        } while (filling);
        ResetFillAmount ();
    }


    public void EndFill () {
        filling = false;
    }


    private void ResetFillAmount () {
        flowerImage.fillAmount = 0.0f;
    }
}
