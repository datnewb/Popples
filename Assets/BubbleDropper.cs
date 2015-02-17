using UnityEngine;
using System.Collections;

public class BubbleDropper : MonoBehaviour {

	public float dropSpeed;
	float currentDropHeight;
	BubbleSpawner bubbleSpawner;

	void Start () {
		currentDropHeight = 0;
		bubbleSpawner = GetComponent<BubbleSpawner>();
	}

	void Update () {
		float currentDropSpeed = dropSpeed * Time.deltaTime;
		currentDropHeight += currentDropSpeed;
		float highestRow = float.MinValue;
		foreach (Bubble bubble in FindObjectsOfType<Bubble>()) {
			bubble.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, currentDropSpeed);
			if (highestRow < bubble.GetComponent<RectTransform>().anchoredPosition.y) {
				highestRow = bubble.GetComponent<RectTransform>().anchoredPosition.y;
			}
		}

		if (currentDropHeight >= bubbleSpawner.bubbleCoordInterval) {
			bubbleSpawner.CreateNewBubbleRow(highestRow + bubbleSpawner.bubbleCoordInterval);
			currentDropHeight -= bubbleSpawner.bubbleCoordInterval;
		}
	}
}
