using UnityEngine;
using System.IO;

public class Saver : MonoBehaviour
{
    public static Saver Instance;

    private void Awake()
    {
        if (Instance == null)
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
        Stats.HighScore = Loader.Instance.Stats.HighScore;
    }

    public PlayerStats Stats;

    [HideInInspector]
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
        Stats.PlayerName = name;

        Debug.Log(name + " " + Stats.PlayerName);
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
            Stats.Score = score;
        }
        else
        {
            Stats.Score = score;
        }
    }

    public void SetDifficulty(int diff)
    {
        Debug.Log(diff);

        gameDifficulty = (Timer.GameDifficulty)diff;

        Debug.Log(gameDifficulty);
    }
}
