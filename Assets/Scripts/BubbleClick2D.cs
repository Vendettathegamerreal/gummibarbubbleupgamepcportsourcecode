using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BubbleClick2D : MonoBehaviour
{
    public BubbleSpawnerUI scoreManager;
    public AudioClip popSFX;
    public float popVolume = 1f;
    public TMP_Text scoreText;

    void OnMouseDown()
    {
        // Play sound
        AudioSource.PlayClipAtPoint(popSFX, Camera.main.transform.position, popVolume);

        // Add score
        scoreManager.AddScore(1);

        // Destroy bubble
        Destroy(gameObject);
    }
}
