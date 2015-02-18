using UnityEngine;
using System.Collections;

public class BubbleDropper : MonoBehaviour
{
    public float dropSpeed;
    public float additionalSpeedMultiplier;
    float currentDropHeight;
    BubbleSpawner bubbleSpawner;

    private GameManager gameManager;

    void Start()
    {
        currentDropHeight = 0;
        bubbleSpawner = GetComponent<BubbleSpawner>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gameManager.CurrentGameState == GameState.Game)
        {
            if (!GetComponent<Canvas>().enabled)
                GetComponent<Canvas>().enabled = true;
            if (gameManager.gameStats == null)
                gameManager.gameStats = FindObjectOfType<GameStats>();
            else
            {
                float currentDropSpeed = (dropSpeed + additionalSpeedMultiplier * gameManager.gameStats.Combo) * Time.deltaTime;
                currentDropHeight += currentDropSpeed;
                float highestRow = float.MinValue;
                foreach (Bubble bubble in FindObjectsOfType<Bubble>())
                {
                    bubble.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, currentDropSpeed);
                    if (highestRow < bubble.GetComponent<RectTransform>().anchoredPosition.y)
                    {
                        highestRow = bubble.GetComponent<RectTransform>().anchoredPosition.y;
                    }
                }

                if (currentDropHeight >= bubbleSpawner.bubbleCoordInterval)
                {
                    bubbleSpawner.CreateNewBubbleRow(highestRow + bubbleSpawner.bubbleCoordInterval);
                    currentDropHeight -= bubbleSpawner.bubbleCoordInterval;
                }
            }
        }
        else
            GetComponent<Canvas>().enabled = false;
    }
}
