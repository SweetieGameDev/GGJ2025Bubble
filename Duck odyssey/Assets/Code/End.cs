using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject GamePlayUI;
    public GameObject WinUI;
    public Button winFirstButton;
    public GameObject LoseUI;
    public Button loseFirstButton;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        GamePlayUI.SetActive(true);
        WinUI.SetActive(false);
        LoseUI.SetActive(false);
    }

    public void WinState()
    {
        GamePlayUI.SetActive(false);
        WinUI.SetActive(true);
        LoseUI.SetActive(false);

        eventSystem.SetSelectedGameObject(winFirstButton.gameObject);

        StopCoroutine(FindFirstObjectByType<SpawnObjects>().SpawnPrefabs());
        StopCoroutine(FindFirstObjectByType<SpawnBubbles>().SpawnPrefabs());
    }

    public void LoseState()
    {
        GamePlayUI.SetActive(false);
        WinUI.SetActive(false);
        LoseUI.SetActive(true);

        eventSystem.SetSelectedGameObject(loseFirstButton.gameObject);

        StopCoroutine(FindFirstObjectByType<SpawnObjects>().SpawnPrefabs());
        StopCoroutine(FindFirstObjectByType<SpawnBubbles>().SpawnPrefabs());
    }

    public void Replay()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        string currentSceneName = SceneManager.GetActiveScene().name;

        // Get the active scene
        Scene currentScene = SceneManager.GetActiveScene();

        // Reload the current scene
        SceneManager.LoadScene(currentScene.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
