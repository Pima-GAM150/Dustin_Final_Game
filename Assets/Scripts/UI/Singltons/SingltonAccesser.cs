using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SingltonAccesser : MonoBehaviour
{
    public Text HighScoretext;
    public GameObject LoadingPanel;
    public Image Bar;
    public GameObject PauseMenu;

    private void Start()
    {
        InputListener handle = InputListener.Instance;

        handle.PausePressed.AddListener(PauseGame);
    }

    private void OnDisable()
    {
        InputListener handle = InputListener.Instance;

        handle.PausePressed.RemoveListener(PauseGame);
    }

    public void SetDifficulty(int diff)
    {
        Saver.Instance.SetDifficulty(diff);
    }

    public void LoadHighScores()
    {
        HighScoretext.gameObject.SetActive(true);

        HighScoretext.text = Loader.Instance.GetHighScore();
    }

    public void SetPlayerName(string name)
    {
        Saver.Instance.SetName(name);
    }

    public void SetScore(int score)
    {
        Saver.Instance.SetScore(score);
    }

    public void LetsRace()
    {
        Saver.Instance.Save();

        LoadLevel("Level1");
    }

    public void Level2()
    {
        Saver.Instance.Save();

        LoadLevel("Level2");
    }
    
    public void GoToEnding()
    {
        LoadLevel("Ending");
    }
	
    public void GoToMainMenu()
    {
        Saver.Instance.Save();

        Saver.Instance.ResetScore();

        Time.timeScale = 1;

        LoadLevel("MainMenu");
    }

    public void GoToInput()
    {
        LoadLevel("Input");
    }

    public void GoToHighScoreVeiwer()
    {
        LoadLevel("TitleSecret");
    }

    public void LetsQuit()
    {
        UIController.Instance.QuitGame();
    }

    public void PauseGame()
    {
        Debug.Log("puseGameCalled");
        PauseMenu.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        PauseMenu.gameObject.SetActive(true);

        UIController.Instance.Resume();
    }

    public void LoadLevel(string name)
    {
        LoadingPanel.SetActive(true);

        StartCoroutine(AsyncLoad(name));
    }

    IEnumerator AsyncLoad(string scene)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(scene);

        while (!load.isDone)
        {
            float progress = Mathf.Clamp01(load.progress / .9f);

            Bar.fillAmount = progress;

            yield return null;
        }
    }
}
