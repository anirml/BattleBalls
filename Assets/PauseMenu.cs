using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

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
        SceneManager.LoadScene("QuickStartMenuDemo");
        PhotonNetwork.Disconnect();
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}