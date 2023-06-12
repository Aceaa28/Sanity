using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject gameScreen;
    private bool isPaused = false;
    public GameObject player;
    public string scene;
    public GameObject gameOverScreen;
    private bool isGameOver = false;
    public Transform characterTransform;
    public float fallingThreshold = -66f;
    private Coroutine hideMenuCoroutine;
    public Button startButton;

    // Start is called before the first frame update
    
    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }

        if (characterTransform.position.y <= fallingThreshold)
        {
            EndGame();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Set time scale to 0 to pause the game
            Invoke("ShowScreen", 0f);
            MusicManager.Instance.PlayEffects("Paused");
        }
        else
        {
            Time.timeScale = 1f; // Set time scale back to 1 to resume the game
            //gameScreen.SetActive(false); // Hide the menu panel
            Invoke("HideMenu", 1f);
            Debug.Log("Done");
            MusicManager.Instance.PlayEffects("NotPaused");
        }       
    }


    private void HideMenu()
    {
        gameScreen.SetActive(false);
        Debug.Log("Hide");
    }

   public void GameStart()
   {
        Debug.Log("Start");
        MusicManager.Instance.PlayEffects("Confirm");

        // Disable the start button
        // startButton.interactable = false;
        // Cancel any previous invocations of HideMenu
        //CancelInvoke("HideMenu"); 
        //Invoke("HideMenu", 1f);
           if (hideMenuCoroutine != null)
    {
        StopCoroutine(hideMenuCoroutine);
    }

        hideMenuCoroutine = StartCoroutine(HideMenuWithDelay(0f));
    }

private IEnumerator HideMenuWithDelay(float delay)
{
    yield return new WaitForSeconds(delay);

    Debug.Log("Hiding Menu");
    gameScreen.SetActive(false);
}

   public void GameRestart()
   {
        Debug.Log("Start Over");
        MusicManager.Instance.PlayEffects("Confirm");
        SceneManager.LoadScene(scene);
        //Invoke("HideMenu", 1f);

        if (hideMenuCoroutine != null)
    {
        StopCoroutine(hideMenuCoroutine);
    }

        hideMenuCoroutine = StartCoroutine(HideMenuWithDelay(0f));
   }

   public void GameQuit()
   {
        Debug.Log("Game Quit");
        MusicManager.Instance.PlayEffects("Confirm");
         #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
   }

   public void MainMenu()
   {
        Debug.Log("Main");
        //sShowScreen();
        Invoke("ShowScreen", 1f);
   }
	
    public void ShowScreen()
    {
        // Enable the start 
        Debug.Log("Show");
        //startButton.interactable = true;
        gameScreen.SetActive(true);
    }

    public void EndGame()
    {
        isGameOver = true;

        // Activate the game over screen
        gameOverScreen.SetActive(true);

        Debug.Log("EndGame called from Player");
    }
}
