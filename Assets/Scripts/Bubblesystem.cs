using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bubblesystem : MonoBehaviour
{
    public float speed = 3f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Destroy if off-screen
        float camHeight = 2f * mainCamera.orthographicSize;
        if (transform.position.y > camHeight / 2f + 1f)
        {
            Destroy(gameObject);
        }
    }
}
