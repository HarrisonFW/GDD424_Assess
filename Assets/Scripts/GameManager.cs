using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject deathScreenPanel;
    public Button retryButton;

    private void Start()
    {
        if (deathScreenPanel != null)
            deathScreenPanel.SetActive(false);

        if (retryButton != null)
            retryButton.onClick.AddListener(RestartLevel);
    }

    public void PlayerDied() // once the player dies this pauses the world (with the time scale), activates the death screen UI to become enabled and unlocks the cursor
    {
        Time.timeScale = 0f;

        if (deathScreenPanel != null)
            deathScreenPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartLevel() // restarts the level after the button is pressed and re-locks the cursor and makes it invisible
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
