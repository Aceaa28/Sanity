using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 6;
    public float currentHealth;
    bool hurt = false;
    bool dead = false;
    public Animator anim;
    public float hurtAnimationDuration = 2f; // Adjust the duration as needed

    //public static float maxHealth;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;


    // Start is called before the first frame update
    void Start()
   {
        currentHealth = maxHealth;
    }

     void Awake ()
    {
        maxHealth = 6;
    }

    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart; 
        }

        for (int i = 0; i <= maxHealth; i++)
        {
            hearts[i].sprite = fullHeart;
        }
    }

   public void TakeDamage(float damageAmount)
   {
     Debug.Log("Taking damage: " + damageAmount);
     maxHealth--;
     currentHealth -= damageAmount;
       Debug.Log(currentHealth);
        if (currentHealth > 0)
        {
            anim.SetBool("Hurt", true);
			hurt = true;

            StartCoroutine(ResetHurtParameter());
        }

        else
        {
            anim.SetBool("Hurt", false);
			hurt = false;
        }

        if(maxHealth <=0)
        {

        // Check if the player has been defeated
       if (currentHealth <= 0)
        {
           Die();
        }
        }
    }

    private IEnumerator ResetHurtParameter()
    {
        yield return new WaitForSeconds(hurtAnimationDuration);

        anim.SetBool("Hurt", false);
        hurt = false;
    }

    private void Die()
    {
        // Implement death behavior, such as resetting the level or game over logic.
            anim.SetBool("Dead", true);
		    dead = true;    
    }
}
