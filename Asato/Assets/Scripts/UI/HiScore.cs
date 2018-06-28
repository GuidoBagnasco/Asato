using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiScore : MonoBehaviour {

    public UnityEngine.UI.Text hiScore;


    private void Start () {
        hiScore.text = "HiScore " + Get ().ToString ("00000");
    }


    public static int Get (int score = 0) {
		string key = "HiScore";
        int hiScore = PlayerPrefs.GetInt (key, 0);
        if (score > hiScore) {
			PlayerPrefs.SetInt (key, score);
            hiScore = score;         
        }
        return hiScore;
    }

}
