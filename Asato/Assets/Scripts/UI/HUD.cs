using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class HUD : Singleton<HUD> {

    public UnityEngine.UI.Image healthBar;
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text ammoText;

    public GameObject gameOverScreen;
    public UnityEngine.UI.Text finalScoreText;
	public UnityEngine.UI.Text hiScoreText;


    public enum ElementType {
        HEALTH,
        SCORE,
        AMMO
    }



    public void UpdateElement (ElementType text, int value) {
        switch (text) {
            case ElementType.HEALTH:
                healthBar.fillAmount = (float)value / 100f;
                break;
            case ElementType.AMMO:
                ammoText.text = value.ToString();
                break;
            case ElementType.SCORE:
                scoreText.text = value.ToString("00000");
                break;
        }
    }


    public void Show () {
        gameOverScreen.SetActive (true);
        int score = (MeiStats.Instance as MeiStats).GetScore();
		finalScoreText.text = "Score " + score.ToString ("00000");
        hiScoreText.text = "Hi-Score " + HiScore.Get (score).ToString ("00000");
        gameObject.SetActive (false);
    }

}
