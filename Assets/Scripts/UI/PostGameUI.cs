using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PostGameUI : MonoBehaviour 
{
    public Text finalScoreText;
    public Text highestComboText;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        finalScoreText.text = "SCORE : " + gameManager.gameStats.Score.ToString();
        highestComboText.text = "HIGHEST COMBO : " + gameManager.gameStats.highestCombo.ToString();
    }

    public void PlayAgain()
    {
        gameManager.gameStats.ResetGameStats();
        Application.LoadLevel(1);
    }

    public void BackToMainMenu()
    {
        Application.LoadLevel(0);
    }
}
