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

    public void QuitGame()
    {
        Saver.Instance.Save();

        Application.Quit();
    }

    public void Pause()
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
