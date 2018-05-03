using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class HUD : MonoBehaviour
{

    public UnityEngine.UI.Text healthText;
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Text ammoText;

    public GameObject gameOverScreen;
    public UnityEngine.UI.Text finalScoreText;
    public static HUD Instance;

    public enum TextType
    {
        HEALTH,
        SCORE,
        AMMO
    }


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) DestroyImmediate(this);
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
        finalScoreText.text = PlayerStats.Instance.GetScore().ToString("00000");
        if (CrossPlatformInputManager.GetButtonDown("Restart")) UnityEngine.SceneManagement.SceneManager.LoadScene("Test");
    }
}
