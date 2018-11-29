using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        InputListener handle = InputListener.Instance;

        handle.PausePressed.AddListener(Pause);
    }

    private void OnDisable()
    {
        InputListener handle = InputListener.Instance;

        handle.PausePressed.RemoveListener(Pause);
    }

    public void Input()
    {
        SceneManager.LoadScene("Input");
    }

    public void QuitGame()
    {
        Saver.Instance.Save();

        Time.timeScale = 1f;

        Application.Quit();
    }

    public void TitleSecret()
    {
        SceneManager.LoadScene("TitleSecret");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Level()
    {
        Loader.Instance.Load();

        Saver.Instance.Stats.HighScore = Loader.Instance.Stats.HighScore;

        SceneManager.LoadScene("Level");
    }

    public void Ending()
    {
        Saver.Instance.Save();
        SceneManager.LoadScene("Ending");
    }

    private void Pause()
    {
        Debug.Log("pause called");

        Player.PlayerS.PauseMenu.SetActive(true);

        Player.PlayerS.GetComponent<PlayerMovement>().Paused = true;

        Time.timeScale = .001f;

        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        Player.PlayerS.PauseMenu.SetActive(false);

        Player.PlayerS.GetComponent<PlayerMovement>().Paused = false;

        Time.timeScale = 1f;
    }
}
