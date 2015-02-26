using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameUI : MonoBehaviour 
{
    public Text scoreText;
    public Text comboText;
    public Text timeText;
    public Text hugeMessageText;
    public Slider timeSlider;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

	void Update () 
    {
        if (gameManager.gameStats != null)
        {
            scoreText.text = gameManager.gameStats.Score.ToString();
            if (gameManager.gameStats.Combo <= 0)
                comboText.text = "";
            else
                comboText.text = "COMBO\n" + gameManager.gameStats.Combo.ToString();
            timeText.text = ((int)(gameManager.gameStats.CurrentTime)).ToString("00") + ":" + ((int)((gameManager.gameStats.CurrentTime - (int)(gameManager.gameStats.CurrentTime)) * 100)).ToString("00");
            timeSlider.value = gameManager.gameStats.CurrentTime / GameStats.StartTime;

            if (gameManager.gameStats.CurrentTime <= 0)
            {
                hugeMessageText.text = "END";
                Invoke("ChangeScene", 2f);
            }
        }
	}

    public void Pause()
    {
        if (gameManager.gameStats.CurrentTime > 0)
            gameManager.CurrentGameState = GameState.Pause;
    }

    private void ChangeScene()
    {
        Application.LoadLevel(2);
    }
}
