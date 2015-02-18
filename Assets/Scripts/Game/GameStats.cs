using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour 
{
    internal const float StartTime = 5;
    const uint BaseScorePerPair = 50;
    const float ComboMaxTime = 2f;

    uint score;
    uint combo;
    float currentTime;
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
        if (gameManager.CurrentGameState == GameState.Game)
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
            score += BaseScorePerPair;
        else
            score += BaseScorePerPair * combo;
    }

    public void AddCombo()
    {
        combo++;
        if (combo > highestCombo)
            highestCombo = combo;
    }

    public void ResetCombo()
    {
        combo = 0;
        ResetComboTimer();
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
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
            Application.LoadLevel(2);
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
