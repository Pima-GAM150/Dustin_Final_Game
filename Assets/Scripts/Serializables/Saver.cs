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

    public PlayerStats Stats;

    string Path;
    
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
    }

    public void SetScore(int score)
    {
        if (score > Stats.HighScore)
        {
            Stats.HighScore = score;
            Stats.Score = score;
        }
        else
        {
            Stats.Score = score;
        }
    }
}
