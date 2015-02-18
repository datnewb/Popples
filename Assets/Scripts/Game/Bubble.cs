﻿using UnityEngine;
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

    public Image unpoppedImage;
    public Image poppedUnpairedImage;
    public Image poppedPairedImage;

    internal bool imagesSet;

    GameObject gameCanvas;
    bool wasInGameRect;
    bool intersectsGameRect;
    Rect gameCanvasRect;
    Rect bubbleRect;

    void Start()
    {
        gameCanvas = GameObject.Find("Game Canvas");
        wasInGameRect = false;
        intersectsGameRect = false;

        if (unpoppedImage == null ||
            poppedUnpairedImage == null ||
            poppedPairedImage == null)
        {
            imagesSet = false;
        }
        else
            imagesSet = true;
    }

    void Update()
    {
        gameCanvasRect = new Rect(
            0,
            0,
            gameCanvas.GetComponent<RectTransform>().rect.width,
            gameCanvas.GetComponent<RectTransform>().rect.height);

        bubbleRect = new Rect(
            GetComponent<RectTransform>().position.x - GetComponent<RectTransform>().rect.width / 2,
            GetComponent<RectTransform>().position.y - GetComponent<RectTransform>().rect.height / 2,
            GetComponent<RectTransform>().rect.width,
            GetComponent<RectTransform>().rect.height);

        intersectsGameRect = gameCanvasRect.Overlaps(bubbleRect);
        if (wasInGameRect)
        {
            if (!intersectsGameRect)
            {
                if (GameObject.FindObjectOfType<BubblePairHandler>().selectedBubbles.Contains(this))
                {
                    GameObject.FindObjectOfType<BubblePairHandler>().selectedBubbles = new List<Bubble>();
                    GameObject.FindObjectOfType<GameStats>().ResetCombo();
                }
                Destroy(gameObject);
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
        if (imagesSet)
        {
            GetComponent<Button>().image = poppedUnpairedImage;
        }
        GameObject.FindObjectOfType<BubblePairHandler>().selectedBubbles.Add(this);
        GameObject.FindObjectOfType<GameStats>().ResetComboTimer();
        GetComponent<Button>().interactable = false;
    }
}