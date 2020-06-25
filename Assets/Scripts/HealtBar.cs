using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

  public void setHealth(float ammount)
    {
        slider.value = ammount;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void setMaxHealth(float ammount)
    {
        slider.maxValue = ammount;
        slider.value = ammount;
        fill.color = gradient.Evaluate(1f);
    }
}
