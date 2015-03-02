using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour 
{
    internal const float StartTime = 60;
    const uint BaseScorePerBubble = 25;
    const float ComboMaxTime = 1f;

    uint score;
    uint combo;
    float currentTime = StartTime;
    float currentComboTime;

    internal uint highestCombo;

    private GameManager gameManager;

	void Start () 
    {
        ResetGameStats();
        gameManager = FindObjectOfType<GameManager>();
	}

    void Update()
    {
        if (gameManager.CurrentGameState == GameState.Game &&
            FindObjectsOfType<CountDownTimer>().Length <= 0 && 
            CurrentTime > 0)
        {
            UpdateTime();
            CheckCombo();
        }
    }

    public uint Score
    {
        get
        {
            return score;
        }
        set { }
    }

    public uint Combo
    {
        get
        {
            return combo;
        }
        set { }
    }

    public float CurrentTime
    {
        get
        {
            return currentTime;
        }
        set { }
    }

    public void AddScore()
    {
        if (combo <= 0)
            score += BaseScorePerBubble;
        else
            score += BaseScorePerBubble * combo;
    }

    public void AddCombo()
    {
        combo++;
        if (combo > highestCombo)
            highestCombo = combo;
        GameObject.Find("GraphicsComponentsManager").GetComponent<GraphicsComponentsManager>().AddComboGraphics(combo);
    }

    public void ResetCombo()
    {
        if (FindObjectsOfType<ComboShield>().Length <= 0)
            combo = 0;
        ResetComboTimer();
        GameObject[] powerUpGraphics = GameObject.FindGameObjectsWithTag("PowerUpGraphic");
        foreach (GameObject x in powerUpGraphics)
        {
            Destroy(x);
        }
    }

    public void ResetGameStats()
    {
        score = 0;
        combo = 0;
        currentTime = StartTime;
        currentComboTime = 0;
        highestCombo = 0;
    }

    public void ResetComboTimer()
    {
        currentComboTime = 0;
    }

    private void UpdateTime()
    {
        if (FindObjectOfType<FreezeTime>() != null)
            currentTime -= Time.deltaTime / 4;
        else
            currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;

            Destroy(GetComponent<DoubleScore>());
            Destroy(GetComponent<FreezeTime>());
            Destroy(GetComponent<ComboShield>());
        }
    }

    private void CheckCombo()
    {
        if (combo > 0)
        {
            currentComboTime += Time.deltaTime;
            if (currentComboTime >= ComboMaxTime)
            {
                ResetCombo();
            }
        }
    }
}
