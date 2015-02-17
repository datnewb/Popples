using UnityEngine;
using System.Collections.Generic;

enum BubbleRowType
{
    Trio,
    Quartet
}

public class BubbleSpawner : MonoBehaviour
{

    public List<GameObject> bubbles;

    float trio_StartX = -73f;
    float quad_StartX = -109.5f;
    internal float bubbleCoordInterval = 73f;
    BubbleRowType currentRowType = BubbleRowType.Quartet;

    GameObject gameCanvas;

    void Start()
    {
        gameCanvas = GameObject.Find("Game Canvas");
        PopulateBubbles();
    }

    void Update()
    {

    }

    //Used to fill screen with bubbles
    void PopulateBubbles()
    {

        for (float startPosY = bubbleCoordInterval * 2; startPosY >= -(gameCanvas.GetComponent<RectTransform>().rect.height); startPosY -= bubbleCoordInterval)
        {
            CreateNewBubbleRow(startPosY);
        }
    }

    //Used to spawn a new row of bubbles
    internal void CreateNewBubbleRow(float yPosition)
    {
        GameObject bubbleInstance;
        int maxBubblesInRow = 0;
        float currentX = 0;

        //Set how many to spawn in this row
        switch (currentRowType)
        {
            case BubbleRowType.Quartet:
                currentX = quad_StartX;
                maxBubblesInRow = 4;
                break;
            case BubbleRowType.Trio:
                currentX = trio_StartX;
                maxBubblesInRow = 3;
                break;
        }

        //Spawn bubbles in row
        for (int bubbleCountInRow = 0; bubbleCountInRow < maxBubblesInRow; bubbleCountInRow++)
        {
            int bubbleIndexToSpawn = Random.Range(0, bubbles.Count);
            bubbleInstance = Instantiate(bubbles[bubbleIndexToSpawn], Vector3.zero, Quaternion.identity) as GameObject;
            bubbleInstance.transform.SetParent(gameCanvas.transform, false);
            bubbleInstance.GetComponent<RectTransform>().anchoredPosition = new Vector2(currentX, yPosition);
            currentX += bubbleCoordInterval;
        }

        //Change how many will spawn next row
        switch (currentRowType)
        {
            case BubbleRowType.Quartet:
                currentRowType = BubbleRowType.Trio;
                break;
            case BubbleRowType.Trio:
                currentRowType = BubbleRowType.Quartet;
                break;
        }
    }
}
