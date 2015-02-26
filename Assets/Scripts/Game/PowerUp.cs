using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PowerUp : MonoBehaviour 
{
    public delegate void PowerUpEffect();

    private List<PowerUpEffect> effects;
    internal PowerUpEffect actualEffect;

    void Start()
    {
        effects = new List<PowerUpEffect>();
        effects.Add(NoEffect);
        effects.Add(DoubleScore);
        effects.Add(SlowTime);
        effects.Add(ComboShield);

        actualEffect = effects[Random.Range(0, effects.Count)];
    }

    private void NoEffect()
    {

    }

    private void DoubleScore()
    {
        FindObjectOfType<GameStats>().gameObject.AddComponent<DoubleScore>();
    }

    private void SlowTime()
    {
        FindObjectOfType<GameStats>().gameObject.AddComponent<FreezeTime>();
    }

    private void ComboShield()
    {

    }
}
