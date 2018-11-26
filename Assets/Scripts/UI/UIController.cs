using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject PauseMenu;

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

    public void StartGame()
    {

    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SaveGame()
    {

    }

    public void TitleSecret()
    {

    }

    private void Pause()
    {
        Time.timeScale = .001f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenu.SetActive(false);
    }
}
