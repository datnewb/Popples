using UnityEngine;
using System.Collections;

public class DoubleScore : MonoBehaviour 
{
    private float time = 5;
    private float timeAdd = 2;

    private BubblePairHandler bubblePairHandler;
    private GameStats gameStats;

    void Start()
    {
        bubblePairHandler = FindObjectOfType<BubblePairHandler>();
        gameStats = FindObjectOfType<GameStats>();

        if (GetComponents<DoubleScore>().Length > 1)
        {
            foreach (DoubleScore doubleScore in GetComponents<DoubleScore>())
            {
                if (doubleScore == this)
                    continue;

                doubleScore.time += timeAdd;
            }

            Destroy(this);
        }
    }

	void Update () 
    {
        if (bubblePairHandler.selectedBubbles.Count == 2)
        {
            if (bubblePairHandler.selectedBubbles[0].bubbleColor == bubblePairHandler.selectedBubbles[1].bubbleColor)
                gameStats.AddScore();
        }

        time -= Time.deltaTime;
        if (time <= 0)
            Destroy(this);
	}
}
