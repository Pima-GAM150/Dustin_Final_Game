using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Timer : MonoBehaviour
{
    public enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }

    public UnityEvent HitZero;

    public GameDifficulty Difficulty = GameDifficulty.Easy;

    public Text TimerText;

    public float EasyTime, MediumTime, HardTime;

    private float AllotedTime;

    private void Start()
    {
        switch(Difficulty)
        {
            case GameDifficulty.Easy:
                AllotedTime = EasyTime;
                break;
            case GameDifficulty.Medium:
                AllotedTime = MediumTime;
                break;
            case GameDifficulty.Hard:
                AllotedTime = HardTime;
                break;
        }
        TimerText.text = AllotedTime.ToString();
    }

    IEnumerator CountDownTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);

            AllotedTime -= 1;

            TimerText.text = AllotedTime.ToString();

            if (AllotedTime <= 0)
            {
                HitZero?.Invoke();
            }
        }
    }
}
