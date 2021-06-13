using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private Scene lobbyScene;

    // void Start() 
    // {
    //     lobbyScene.name = SceneManager.GetActiveScene().name;
    //     Debug.Log("Scene Name: " + lobbyScene.name);
    // }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        // SceneManager.LoadScene(lobbyScene.name);
        // TODO: Don't do it like this below...
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("QuickStartMenuDemo");

    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}