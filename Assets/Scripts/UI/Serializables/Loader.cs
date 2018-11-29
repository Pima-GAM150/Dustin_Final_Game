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

    [HideInInspector]
    public string PlayerString;

    [HideInInspector]
    public PlayerStats Stats;

    public Text HighScoreText;

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

    public void GetHighScore()
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
            HighScoreText.text = "What are you thinking?? There are NO Highscores yet.";
        }
        else
        {
            HighScoreText.text = "Easy "+ Stats.HighScore[0] 
                                +"\nMeduim " + Stats.HighScore[1]
                                + "\nHard " + Stats.HighScore[2];
        }
    }

}
