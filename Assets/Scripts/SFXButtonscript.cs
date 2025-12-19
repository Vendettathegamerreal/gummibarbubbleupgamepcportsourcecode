using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXButtonscript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;

    public void PlayClick()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
