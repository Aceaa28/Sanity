using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider musicSlider, effectsSlider;

    public void ToggleMusic()
    {
        MusicManager.Instance.ToggleMusic();
    }

    public void ToggleEffects()
    {
        MusicManager.Instance.ToggleEffects();
    }

    public void MusicVolume()
    {
        MusicManager.Instance.MusicVolume(musicSlider.value);
    }

    public void EffectsVolume()
    {
        MusicManager.Instance.EffectsVolume(effectsSlider.value);
    }
}
