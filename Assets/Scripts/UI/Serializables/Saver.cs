using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Saver : MonoBehaviour
{
    public static Saver Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Score = 0;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        Loader.Instance.Load();

        if(SceneManager.GetActiveScene().name == "Input")
        {
            Stats.LastPlayer = Loader.Instance.Stats.LastPlayer;
        }

        Stats.HighScore = Loader.Instance.Stats.HighScore;
        Stats.PlayerName = Loader.Instance.Stats.PlayerName;
    }

    public PlayerStats Stats;

    public int Score;

    public Timer.GameDifficulty gameDifficulty;

    string Path;
    int index;
    
    public void Save()
    {
        string PlayerJson = string.Empty;

        PlayerJson = JsonUtility.ToJson(Stats);

        if (PlayerJson != null)
        {
            Path = Application.streamingAssetsPath + "/PlayerStats.json";

            File.WriteAllText(Path, PlayerJson);
        }
       
    }
    
    public void SetName(string name)
    {
        Stats.LastPlayer = name;
    }

    public void SetScore(int score)
    {
        switch(gameDifficulty)
        {
            case Timer.GameDifficulty.Easy:
                index = 0;
            break;
            case Timer.GameDifficulty.Medium:
                index = 1;
            break;
            case Timer.GameDifficulty.Hard:
                index = 2;
            break;
        }

        if (score > Stats.HighScore[index])
        {
            Stats.HighScore[index] = score;
            Stats.PlayerName[index] = Stats.LastPlayer;

            Score += score;
        }
        else
        {
            Score += score;
        }
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public void SetDifficulty(int diff)
    {
        Debug.Log(diff);

        gameDifficulty = (Timer.GameDifficulty)diff;

        Debug.Log(gameDifficulty);
    }
}
