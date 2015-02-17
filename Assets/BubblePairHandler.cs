using UnityEngine;
using System.Collections.Generic;

public class BubblePairHandler : MonoBehaviour
{
    internal List<Bubble> selectedBubbles;

    void Start()
    {
        selectedBubbles = new List<Bubble>();
    }

    void Update()
    {
        if (selectedBubbles.Count >= 2)
        {
            if (selectedBubbles[0].bubbleColor == selectedBubbles[1].bubbleColor)
            {
                GameObject.FindObjectOfType<PrototypeUI>().score.text = (int.Parse(GameObject.FindObjectOfType<PrototypeUI>().score.text) + 50).ToString();
            }
            selectedBubbles = new List<Bubble>();
        }
    }
}