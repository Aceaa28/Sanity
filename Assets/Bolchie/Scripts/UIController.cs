using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject gameScreen;
    private bool isPaused = false;
   
    // Start is called before the first frame update
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Set time scale to 0 to pause the game
            gameScreen.SetActive(true); // Show the menu panel
            MusicManager.Instance.PlayEffects("Paused");
        }
        else
        {
            Time.timeScale = 1f; // Set time scale back to 1 to resume the game
            gameScreen.SetActive(false); // Hide the menu panel
            MusicManager.Instance.PlayEffects("NotPaused");
        }


    }


    private void HideMenu()
    {
        gameScreen.SetActive(false);
    }

   public void GameStart()
   {
        Debug.Log("Start");
         // Hide the menu after a delay
        Invoke("HideMenu", 3f);
        //SceneManager.LoadScene("Tutorial");
        MusicManager.Instance.PlayEffects("Confirm");
    }

   public void GameRestart()
   {
        Debug.Log("Start Over");
        //SceneManager.LoadScene("Tutorial");
        Invoke("HideMenu", 3f);
        MusicManager.Instance.PlayEffects("Confirm");
    }

   public void GameQuit()
   {
        Debug.Log("Game Quit");
         #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        MusicManager.Instance.PlayEffects("Confirm");
   }
	
    public void ShowScreen()
    {
        gameScreen.SetActive(true);
    }
}
