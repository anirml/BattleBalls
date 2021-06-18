using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;

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
            if (gameIsPaused)
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
        gameIsPaused = false;
        MusicManager.Instance.PlayBackgroundMusic();
    }
    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
        MusicManager.Instance.PauseBackgroundMusic();
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