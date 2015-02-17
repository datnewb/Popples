using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PrototypeUI : MonoBehaviour 
{
    public Text score;

    void Start()
    {
        score.text = "0";
    }

    public void Restart()
    {
        Application.LoadLevel(0);
    }
}
