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

    public void PlayerDied()
    {
        Time.timeScale = 0f;

        if (deathScreenPanel != null)
            deathScreenPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
