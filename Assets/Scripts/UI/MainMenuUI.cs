using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuUI : MonoBehaviour 
{
    [SerializeField]
    AudioClip buttonSelectAudio;

    [SerializeField]
    Image audioButtonImage;
    [SerializeField]
    Sprite audioOn;
    [SerializeField]
    Sprite audioOff;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (AudioListener.volume == 0)
        {
            audioButtonImage.sprite = audioOff;
        }
        else
        {
            audioButtonImage.sprite = audioOn;
        }
    }

    public void StartGame()
    {
        gameManager.CurrentGameState = GameState.Game;
        audio.PlayOneShot(buttonSelectAudio);
        Application.LoadLevel(1);
    }

    public void ExitGame()
    {
        audio.PlayOneShot(buttonSelectAudio);
        Application.Quit();
    }

    public void ChangeAudio()
    { 
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            audioButtonImage.sprite = audioOn;
        }
        else
        {
            AudioListener.volume = 0;
            audioButtonImage.sprite = audioOff;
        }

        audio.PlayOneShot(buttonSelectAudio);
    }
}
