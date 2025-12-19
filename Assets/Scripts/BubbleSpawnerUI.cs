using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class BubbleSpawnerUI : MonoBehaviour
{
    [Header("Bubble Settings")]
    public Sprite bubbleSprite;          // Assign a bubble sprite
    public Vector2 bubbleScaleRange = new Vector2(0.5f, 1.5f);
    public float speedMin = 2f;
    public float speedMax = 5f;
    public float spawnIntervalMin = 0.5f;
    public float spawnIntervalMax = 1.5f;

    [Header("Score & Audio")]
    public TMP_Text scoreText;           // Assign score text
    public AudioClip popSFX;             // Assign pop sound
    public float popVolume = 1f;

    private int score = 0;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        scoreText.text = "Score: 0";
        StartCoroutine(SpawnBubbles());
    }

    IEnumerator SpawnBubbles()
    {
        while (true)
        {
            // Create bubble GameObject
            GameObject bubble = new GameObject("Bubble");
            bubble.transform.position = GetRandomBottomPosition();

            // Add SpriteRenderer
            SpriteRenderer sr = bubble.AddComponent<SpriteRenderer>();
            sr.sprite = bubbleSprite;
            sr.color = new Color(Random.value, Random.value, Random.value, 1f);

            // Random scale
            float scale = Random.Range(bubbleScaleRange.x, bubbleScaleRange.y);
            bubble.transform.localScale = new Vector3(scale, scale, 1f);

            // Add CircleCollider2D for click detection
            CircleCollider2D collider = bubble.AddComponent<CircleCollider2D>();
            collider.isTrigger = true;

            // Add BubbleMovement component
            Bubblesystem movement = bubble.AddComponent<Bubblesystem>();
            movement.speed = Random.Range(speedMin, speedMax);

            // Add click detection
            BubbleClick2D click = bubble.AddComponent<BubbleClick2D>();
            click.popSFX = popSFX;
            click.popVolume = popVolume;
            click.scoreText = scoreText;
            click.scoreManager = this;

            // Wait random interval before next bubble
            float waitTime = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(waitTime);
        }
    }

    Vector3 GetRandomBottomPosition()
    {
        float camHeight = 2f * mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        float x = Random.Range(-camWidth / 2f, camWidth / 2f);
        float y = -camHeight / 2f - 1f; // start just below screen
        return new Vector3(x, y, 0f);
    }

    // Called by BubbleClick2D
    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score;
    }
}
