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

        int x = Random.Range(0, effects.Count);
        actualEffect = effects[x];

        switch(x)
        {
            case 0:
                break;
            case 1:
                FindObjectOfType<GraphicsComponentsManager>().AddPowerUpGraphics("DoubleScore", this.gameObject);
                this.GetComponent<Bubble>().effect = "DoubleScore";
                break;
            case 2:
                FindObjectOfType<GraphicsComponentsManager>().AddPowerUpGraphics("FreezeTime", this.gameObject);
                this.GetComponent<Bubble>().effect = "FreezeTime";
                break;
            case 3:
                FindObjectOfType<GraphicsComponentsManager>().AddPowerUpGraphics("ComboShield", this.gameObject);
                this.GetComponent<Bubble>().effect = "ComboShield";
                break;

        }
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
        FindObjectOfType<GameStats>().gameObject.AddComponent<ComboShield>();
    }
}
