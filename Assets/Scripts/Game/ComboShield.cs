﻿using UnityEngine;
using System.Collections;

public class ComboShield : MonoBehaviour 
{
    private float time = 2.5f;

    void Start()
    {
        if (GetComponents<ComboShield>().Length > 1)
        {
            foreach (ComboShield comboShield in GetComponents<ComboShield>())
            {
                if (comboShield == this)
                    continue;

                comboShield.time = time;
            }
            Destroy(this);
        }
    }

    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            FindObjectOfType<GraphicsComponentsManager>().comboShieldInEffect = false;
            Destroy(this);
        }
        else
        {
            FindObjectOfType<GraphicsComponentsManager>().comboShieldInEffect = true;
        }
    }
}
