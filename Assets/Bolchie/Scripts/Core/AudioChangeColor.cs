using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioChangeColor : MonoBehaviour
{
    public Image musicButton, sfxButton;
    public Color color1, color2;
    bool isChanged = false;

    public void ChangeMusicButtonColor()
    {
        if (isChanged == false)
        {
            musicButton.color = color2;
            isChanged = true;
        }
        else
        {
            musicButton.color = color1;
            isChanged = false;
        }
    }

    public void ChangeSFXButtonColor()
    {
        if (isChanged == false)
        {
            sfxButton.color = color2;
            isChanged = true;
        }
        else
        {
            sfxButton.color = color1;
            isChanged = false;
        }
    }
}
