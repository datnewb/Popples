using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour 
{
    [SerializeField]
    AudioClip[] popAudios;
    uint currentCombo;
    int selectedBubbles;

    GameManager gameManager;
    BubblePairHandler bubblePairHandler;

    void Start()
    {
        currentCombo = 0;
        selectedBubbles = 0;
        gameManager = FindObjectOfType<GameManager>();
        bubblePairHandler = FindObjectOfType<BubblePairHandler>();
    }

    void Update()
    {
        if (selectedBubbles != bubblePairHandler.selectedBubbles.Count)
        {
            int popAudioIndex = SetAudioIndex();
            audio.PlayOneShot(popAudios[popAudioIndex]);
        }

        selectedBubbles = bubblePairHandler.selectedBubbles.Count;
        currentCombo = gameManager.gameStats.Combo;
    }

    int SetAudioIndex()
    {
        if (currentCombo >= popAudios.Length)
            return popAudios.Length - 1;
        else
            return (int)currentCombo;
    }
}
