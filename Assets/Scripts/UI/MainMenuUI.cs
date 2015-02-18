using UnityEngine;
using System.Collections;

public class MainMenuUI : MonoBehaviour 
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void StartGame()
    {
        gameManager.CurrentGameState = GameState.Game;
        Application.LoadLevel(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
