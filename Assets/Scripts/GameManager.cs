using UnityEngine;
using System.Collections;

public enum GameState
{
    MainMenu,
    Game,
    Pause,
    PostGame
}

public class GameManager : MonoBehaviour 
{
    internal GameState CurrentGameState;
    internal GameStats gameStats;

	void Start () 
    {
        DontDestroyOnLoad(this);

        CurrentGameState = GameState.MainMenu;
        gameStats = null;

        if (FindObjectsOfType<GameManager>().Length > 1)
            Destroy(gameObject);
	}

	void Update () 
    {
        switch (Application.loadedLevel)
        {
            case 0:
                CurrentGameState = GameState.MainMenu;
                break;
            case 1:
                if (CurrentGameState != GameState.Pause)
                    CurrentGameState = GameState.Game;
                else if (CurrentGameState != GameState.Game)
                    CurrentGameState = GameState.Pause;
                break;
            case 2:
                CurrentGameState = GameState.PostGame;
                break;
        }

        switch (CurrentGameState)
        {
            case GameState.MainMenu:
                if (gameStats != null)
                {
                    Destroy(gameStats);
                    gameStats = null;
                }
                break;

            case GameState.Game:
                if (gameStats == null)
                    gameStats = gameObject.AddComponent<GameStats>();
                break;
        }
	}
}
