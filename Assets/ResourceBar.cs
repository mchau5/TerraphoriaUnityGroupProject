using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxResource(float resource)
    {
        slider.maxValue = resource;
        slider.value = resource;
    }

    public void SetResource(float resource)
    {
        slider.value = resource;
    }

    public float GiveMaxResource()
    {
        return slider.maxValue;
    }

    public void ExtraRecovery(float resource)
    {
        slider.value += resource;
    }

    public float GiveValue()
    {
        return slider.value;
    }
}
