using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string scene; // The name of the scene to transition to

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(scene); // Load the destination scene
            MusicManager.Instance.PlayEffects("Portal");
        }
    }
}
