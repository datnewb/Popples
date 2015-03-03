using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PostGameUI : MonoBehaviour 
{
    public Text finalScoreText;
    public Text highestComboText;

    private GameManager gameManager;

    [SerializeField]
    AudioClip buttonSelectAudio;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        finalScoreText.text = "SCORE : " + gameManager.gameStats.Score.ToString();
        highestComboText.text = "HIGHEST COMBO : " + gameManager.gameStats.highestCombo.ToString();
    }

    public void PlayAgain()
    {
        gameManager.gameStats.ResetGameStats();
        audio.PlayOneShot(buttonSelectAudio);
        Application.LoadLevel(1);
    }

    public void BackToMainMenu()
    {
        audio.PlayOneShot(buttonSelectAudio);
        Application.LoadLevel(0);
    }
}
