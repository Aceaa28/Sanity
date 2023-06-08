using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;

    void Start()
    {
        MusicManager.Instance.ChangeMasterVolume(slider.value);
        slider.onValueChanged.AddListener(val => MusicManager.Instance.ChangeMasterVolume(val));
    }
}
