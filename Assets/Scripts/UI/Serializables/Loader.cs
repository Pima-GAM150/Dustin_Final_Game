using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Loader : MonoBehaviour
{
    public static Loader Instance;

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

    string Path;

    string PlayerJson;

    
    public string PlayerString;

    
    public PlayerStats Stats;

    public void Load()
    {
        Path = Application.streamingAssetsPath + "/PlayerStats.json";

        PlayerString = File.ReadAllText(Path);

        if (PlayerString != null)
        {
            Debug.Log(PlayerString);

            Stats = JsonUtility.FromJson<PlayerStats>(PlayerString);
        }
        else
        {
            Stats = null;
        }
    }

    public string GetHighScore()
    {
        int scores = 0;

        bool NoScores = false;

        Load();
        
        foreach (int s in Stats.HighScore)
        {
            if(s<=0)
            {
                scores++;
            }
            if(scores==3)
            {
                NoScores = true;
            }
        }

        if (NoScores)
        {
            return "What are you thinking?? There are NO Highscores yet.";
        }
        else
        {
            return string.Format("{0,-10}{6,-10}{3,10}\n" +
                                 "{1,-10}{7,-10}{4,10}\n" +
                                 "{2,-10}{8,-10}{5,10}\n",
                                 Stats.PlayerName[0], Stats.PlayerName[1], Stats.PlayerName[2],
                                 Stats.HighScore[0], Stats.HighScore[1], Stats.HighScore[2],
                                 "Eas", "Med", "Hrd");
        }
    }

}
