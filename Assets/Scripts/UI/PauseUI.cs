using UnityEngine;
using System.Collections;

public class PauseUI : MonoBehaviour 
{
    private GameManager gameManager;

    void Start()
    {
        GetComponent<Canvas>().enabled = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gameManager.CurrentGameState == GameState.Pause)
        {
            if (!GetComponent<Canvas>().enabled)
                GetComponent<Canvas>().enabled = true;
        }
        else
        {
            if (GetComponent<Canvas>().enabled)
                GetComponent<Canvas>().enabled = false;
        }
    }

    public void Resume()
    {
        gameManager.CurrentGameState = GameState.Game;
    }

    public void BackToMainMenu()
    {
        Application.LoadLevel(0);
        gameManager.CurrentGameState = GameState.MainMenu;
    }

    public void Reset()
    {
        Application.LoadLevel(1);
        if (gameManager.gameStats != null)
            gameManager.gameStats.ResetGameStats();
    }
}
