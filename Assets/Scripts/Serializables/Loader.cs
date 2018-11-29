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
            Stats = JsonUtility.FromJson<PlayerStats>(PlayerString);
        }
        else
        {
            Stats = null;
        }
    }

    public void GetHighScore()
    {
        if (Stats == null)
        {
            HighScoreText.text = "What are you thinking?? There's NO Highscore yet.";
        }
        else
        {
            HighScoreText.text = Stats.HighScore.ToString();
        }
    }

}
