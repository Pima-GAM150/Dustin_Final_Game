using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SingltonAccesser : MonoBehaviour
{
    public Text HighScoretext;
    public GameObject LoadingPanel;
    public Image Bar;

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
        LoadLevel("Level");
    }

    public void GoToEnding()
    {
        LoadLevel("Ending");
    }
	
    public void GoToMainMenu()
    {
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

    public void ResumeGame()
    {
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
