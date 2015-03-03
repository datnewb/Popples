using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseUI : MonoBehaviour 
{
    private GameManager gameManager;

    [SerializeField]
    AudioClip buttonSelectAudio;

    [SerializeField]
    Image audioImage;
    [SerializeField]
    Sprite audioOn;
    [SerializeField]
    Sprite audioOff;

    void Start()
    {
        GetComponent<Canvas>().enabled = false;
        gameManager = FindObjectOfType<GameManager>();

        if (AudioListener.volume == 0)
        {
            audioImage.sprite = audioOff;
        }
        else
        {
            audioImage.sprite = audioOn;
        }
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
        audio.PlayOneShot(buttonSelectAudio);
    }

    public void BackToMainMenu()
    {
        audio.PlayOneShot(buttonSelectAudio);
        Application.LoadLevel(0);
        gameManager.CurrentGameState = GameState.MainMenu;
    }

    public void Reset()
    {
        audio.PlayOneShot(buttonSelectAudio);
        Application.LoadLevel(1);
        gameManager.CurrentGameState = GameState.Game;
        if (gameManager.gameStats != null)
            gameManager.gameStats.ResetGameStats();
    }

    public void ChangeAudio()
    {
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            audioImage.sprite = audioOn;
        }
        else
        {
            AudioListener.volume = 0;
            audioImage.sprite = audioOff;
        }

        audio.PlayOneShot(buttonSelectAudio);
    }
}
