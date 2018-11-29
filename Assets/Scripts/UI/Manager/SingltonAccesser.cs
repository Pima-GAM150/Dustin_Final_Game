using UnityEngine;
using UnityEngine.UI;

public class SingltonAccesser : MonoBehaviour
{
    public Text HighScoretext;

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
        UIController.Instance.Level();
    }

    public void GoToEnding()
    {
        UIController.Instance.Ending();
    }
	
    public void GoToMainMenu()
    {
        UIController.Instance.MainMenu();
    }

    public void GoToInput()
    {
        UIController.Instance.Input();
    }

    public void GoToHighScoreVeiwer()
    {
        UIController.Instance.TitleSecret();
    }

    public void LetsQuit()
    {
        UIController.Instance.QuitGame();
    }

    public void ResumeGame()
    {
        UIController.Instance.Resume();
    }
}
