using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDownTimer : MonoBehaviour 
{
    private float time = 4;

    void Update()
    {
        time -= Time.deltaTime;
        if (time >= 1)
            GetComponent<Text>().text = ((int)time).ToString();
        else if (time > 0)
            GetComponent<Text>().text = "GO!";
        else
        {
            GetComponent<Text>().text = "";
            Destroy(this);
        }
    }
}
