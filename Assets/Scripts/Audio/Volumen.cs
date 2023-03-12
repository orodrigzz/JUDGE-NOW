using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public Slider slider;
    public float sliderVal;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
    }

    public void ChangeSlider (float value)
    {
        sliderVal = value;
        PlayerPrefs.SetFloat("volumenAudio", sliderVal);
        AudioListener.volume = slider.value;
    }
}
