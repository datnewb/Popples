using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class BubblePairHandler : MonoBehaviour
{
    internal List<Bubble> selectedBubbles;
    private GameStats gameStats;

    void Start()
    {
        selectedBubbles = new List<Bubble>();
        gameStats = FindObjectOfType<GameStats>();
    }

    void Update()
    {
        if (gameStats == null)
            gameStats = FindObjectOfType<GameStats>();
        else
        {
            if (selectedBubbles.Count >= 2)
            {
                if (selectedBubbles[0].bubbleColor == selectedBubbles[1].bubbleColor)
                {
                    for (int bubbleIndex = 0; bubbleIndex < selectedBubbles.Count; bubbleIndex++)
                        gameStats.AddScore();

                    gameStats.AddCombo();

                    selectedBubbles[1].gameObject.GetComponent<PowerUp>().actualEffect();
                    foreach (PowerUp powerUp in FindObjectsOfType<PowerUp>())
                        Destroy(powerUp);

                    GameObject.Find("GraphicsComponentsManager").GetComponent<GraphicsComponentsManager>().ShakeScreen();
                }
                else
                {
                    gameStats.ResetCombo();
                }
                foreach (Bubble bubble in selectedBubbles)
                {
                    bubble.gameObject.GetComponent<Button>().image.color = Color.black;
                }
                selectedBubbles = new List<Bubble>();
            }
        }
    }
}