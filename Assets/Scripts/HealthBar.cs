using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    Slider m_slider;

    public Gradient gradient;
    public Image fill;

    private void Awake()
    {
        m_slider = gameObject.GetComponent<Slider>();
    }

    public void SetValue(float newValue)
    {
        m_slider.value = newValue;
        fill.color = gradient.Evaluate(m_slider.normalizedValue);
    }

    public void SetMaxValue(float newValue)
    {
        m_slider.maxValue = newValue;
    }
    
}
