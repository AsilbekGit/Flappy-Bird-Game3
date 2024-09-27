using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 1.0f;
    private bool scored; // Variable to check if score is already added

    private void FixedUpdate()
    {
        transform.position += ((Vector3.left * speed) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && !scored) {
            GameManager gameManager = FindObjectOfType<GameManager>(); // Find the GameManager
            gameManager.IncreaseScore(); // Call IncreaseScore method
            scored = true; // Set scored to true to avoid multiple scores
        }
    }
    private void OnEnable() {
    scored = false; // Reset scored when the obstacle is enabled
}
}
