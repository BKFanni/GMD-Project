using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public Image sliderFill;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        float healthPercent = currentValue / maxValue;
        slider.value = healthPercent;

        if (healthPercent > 0.5f)
        {
            // Interpolate between green and yellow
            sliderFill.color = Color.Lerp(Color.yellow, Color.green, (healthPercent - 0.5f) * 2);
        }
        else if (healthPercent > 0.25f)
        {
            // Interpolate between orange and yellow
            sliderFill.color = Color.Lerp(new Color(1.0f, 0.64f, 0.0f), Color.yellow, (healthPercent - 0.25f) * 4);
        }
        else
        {
            // Interpolate between red and orange
            sliderFill.color = Color.Lerp(Color.red, new Color(1.0f, 0.64f, 0.0f), healthPercent * 4);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
