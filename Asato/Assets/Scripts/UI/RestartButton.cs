using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour {


	public void RestartGame () {
		UnityEngine.SceneManagement.SceneManager.LoadScene("Test");
	}
}
