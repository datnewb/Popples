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
                    gameStats.AddScore();
                    gameStats.AddCombo();
                    GameObject.Find("GraphicsComponentsManager").GetComponent<GraphicsComponentsManager>().ShakeScreen();
                }
                else
                {
                    gameStats.ResetCombo();
                }
                foreach (Bubble bubble in selectedBubbles)
                {
                    if (bubble.imagesSet)
                    {
                        bubble.gameObject.GetComponent<Button>().image = bubble.poppedPairedImage;
                    }
                    else
                        bubble.gameObject.GetComponent<Button>().image.color = Color.black;
                }
                selectedBubbles = new List<Bubble>();
            }
        }
    }
}