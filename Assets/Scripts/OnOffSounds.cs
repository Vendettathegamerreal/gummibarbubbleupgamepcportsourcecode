using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnOffSounds : MonoBehaviour
{
    public AudioSource musicSource;
    public Image musicIcon;
    public Sprite musicOnIcon;
    public Sprite musicOffIcon;

    void Start()
    {
        bool muted = PlayerPrefs.GetInt("Music", 0) == 1;
        musicSource.mute = muted;
        UpdateIcon();
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        PlayerPrefs.SetInt("Music", musicSource.mute ? 1 : 0);
        UpdateIcon();
    }

    void UpdateIcon()
    {
        musicIcon.sprite = musicSource.mute ? musicOffIcon : musicOnIcon;
    }
}
