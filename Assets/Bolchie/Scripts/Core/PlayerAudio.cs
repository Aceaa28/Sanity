using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAudio : MonoBehaviour
{
    AudioSource audioSource;
    public Slider effectsSlider;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnEnable()
    {
        effectsSlider.onValueChanged.AddListener(delegate { ChangeVolume(effectsSlider.value); });
    }

    void ChangeVolume(float sliderValue)
    {
        audioSource.volume = sliderValue;
    }

    public void ToggleEffects()
    {
        audioSource.mute = !audioSource.mute;
    }
}
