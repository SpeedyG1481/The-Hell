using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondSceneSlider : MonoBehaviour
{
    public AudioSource DevilBackgroundAudio;
    public float DevilBackgroundFloat, DevilSfxFloat;
    public AudioSource[] DevilSoundEffectAudio;

    public void Awake()
    {
        UpdateDevilSound();

    }
    public void UpdateDevilSound()
    {
        DevilBackgroundFloat = PlayerPrefs.GetFloat("BackgroundPref");
        DevilBackgroundAudio.volume = DevilBackgroundFloat;
        DevilSfxFloat = PlayerPrefs.GetFloat("SoundEffectsPref");
        for (int i = 0; i < DevilSoundEffectAudio.Length; i++)
        {
            DevilSoundEffectAudio[i].volume = DevilSfxFloat;
        }
    }
}
