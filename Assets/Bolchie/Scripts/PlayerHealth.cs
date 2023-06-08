using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 3;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
   {
        currentHealth = maxHealth;
    }

   public void TakeDamage(float damageAmount)
   {
       currentHealth -= damageAmount;
       Debug.Log(currentHealth);

        // Check if the player has been defeated
       if (currentHealth <= 0)
        {
           Die();
        }
    }

    private void Die()
    {
        // Implement death behavior, such as resetting the level or game over logic.

    }
}
