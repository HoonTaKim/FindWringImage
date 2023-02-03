using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Button menuButton;

    void Start()
    {
        slider.maxValue = 100;        
    }

    public void SliderTime(float time)
    {
        slider.value = time;
    }
}
