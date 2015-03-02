using UnityEngine;
using System.Collections;

public class FreezeTime : MonoBehaviour 
{
    private float time = 2.5f;
    private float timeAdd = 1;

    void Start()
    {
        if (GetComponents<FreezeTime>().Length > 1)
        {
            foreach (FreezeTime freezeTime in GetComponents<FreezeTime>())
            {
                if (freezeTime == this)
                    continue;

                freezeTime.time += timeAdd;
            }
            Destroy(this);
        }
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Destroy(this);
            FindObjectOfType<GraphicsComponentsManager>().freezeTimeInEffect = false;
        }
        else
        {
            FindObjectOfType<GraphicsComponentsManager>().freezeTimeInEffect = true;
        }
    }
}
