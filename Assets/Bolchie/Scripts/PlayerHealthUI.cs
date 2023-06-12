using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{ 
    public GameObject gameOverScreen; // Reference to the game over screen GameObject

    public GameObject fullHeartPrefab; // Reference to the full heart prefab or image
    public GameObject halfHeartPrefab; // Reference to the half heart prefab or image
    public Transform heartsContainer; // Reference to the container for the hearts

    private float remainingLives; // Variable to track the player's remaining lives

    // Call this method to update the heart UI
    public void UpdateHeartUI(float lives)
    {
        remainingLives = lives;
        Debug.Log("Update");

        // Remove all existing hearts
        foreach (Transform child in heartsContainer)
        {
            Destroy(child.gameObject);
             Debug.Log("Des");
        }

        // Calculate the number of full hearts and half hearts
        int fullHearts = Mathf.FloorToInt(remainingLives);
        int halfHearts = Mathf.RoundToInt((remainingLives - fullHearts) * 2);

        // Add full hearts
        for (int i = 0; i < fullHearts; i++)
        {
            Instantiate(fullHeartPrefab, heartsContainer);
             Debug.Log("In");
        }

        // Add half heart if necessary
        if (halfHearts > 0)
        {
            Instantiate(halfHeartPrefab, heartsContainer);
             Debug.Log("Half");
        }

         // Check if remaining lives reached zero
        if (remainingLives <= 0)
        {
            GameOver();
             Debug.Log("Game");
        }
    }

    // Activate the game over screen
    private void GameOver()
    {
        gameOverScreen.SetActive(true);
         Debug.Log("Set");
    }
}
