using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class HUD : Singleton<HUD> {

    public UnityEngine.UI.Text healthText;
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text ammoText;

    public GameObject gameOverScreen;
    public UnityEngine.UI.Text finalScoreText;


    public enum TextType
    {
        HEALTH,
        SCORE,
        AMMO
    }



    public void UpdateText(TextType text, int value)
    {
        switch (text)
        {
            case TextType.HEALTH:
                healthText.text = "Health " + value;
                break;
            case TextType.AMMO:
                ammoText.text = "Ammo " + value;
                break;
            case TextType.SCORE:
                scoreText.text = value.ToString("00000");
                break;
        }
    }


    public void GameOver() {
        gameOverScreen.SetActive(true);
        finalScoreText.text = MeiStats.Instance.GetScore().ToString("00000");
    }
}
