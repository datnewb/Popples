using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public enum BubbleColor
{
    Red,
    Blue,
    Green
}

public class Bubble : MonoBehaviour
{
    public BubbleColor bubbleColor;

    GameObject gameCanvas;
    bool wasInGameRect;
    bool intersectsGameRect;
    Rect gameCanvasRect;
    internal Rect bubbleRect;

    void Start()
    {
        gameCanvas = GameObject.Find("Game Canvas");
        wasInGameRect = false;
        intersectsGameRect = false;
    }

    void Update()
    {
        gameCanvasRect = gameCanvas.GetComponent<Canvas>().pixelRect;

        bubbleRect = new Rect(
            GetComponent<RectTransform>().position.x - GetComponent<RectTransform>().rect.width / 2,
            GetComponent<RectTransform>().position.y - GetComponent<RectTransform>().rect.height / 2,
            GetComponent<RectTransform>().rect.width,
            GetComponent<RectTransform>().rect.height);

        intersectsGameRect = gameCanvasRect.Overlaps(bubbleRect, true);
        if (wasInGameRect)
        {
            if (!intersectsGameRect)
            {
                if (FindObjectOfType<BubblePairHandler>().selectedBubbles.Contains(this))
                {
                    FindObjectOfType<BubblePairHandler>().selectedBubbles = new List<Bubble>();
                    FindObjectOfType<GameStats>().ResetCombo();
                }
                Invoke("DestroyBubble", 0.2f);
            }
        }
        else
        {
            if (intersectsGameRect)
            {
                wasInGameRect = true;
            }
        }
    }

    public void Pop()
    {
        if (FindObjectsOfType<CountDownTimer>().Length <= 0 && 
            FindObjectOfType<GameStats>().CurrentTime > 0)
        {
            BubblePairHandler bubblePairHandler = FindObjectOfType<BubblePairHandler>();
            bubblePairHandler.selectedBubbles.Add(this);
            if (bubblePairHandler.selectedBubbles.Count == 1)
            {
                AddPowerUps(bubbleColor);
            }

            FindObjectOfType<GameStats>().ResetComboTimer();
            GetComponent<Button>().interactable = false;
            GameObject.Find("GraphicsComponentsManager").GetComponent<GraphicsComponentsManager>().PopGraphics(GetComponent<RectTransform>(), GetComponent<Image>().sprite);
        }
    }

    private void DestroyBubble()
    {
        Destroy(gameObject);
    }

    private void AddPowerUps(BubbleColor bubbleColor)
    {
        Bubble[] bubbles = FindObjectsOfType<Bubble>();
        foreach (Bubble bubble in bubbles)
        {
            if (bubble != this)
            {
                if (bubble.bubbleColor == bubbleColor)
                {
                    bubble.gameObject.AddComponent<PowerUp>();
                }
            }
        }
    }
}
