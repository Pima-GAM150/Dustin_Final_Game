using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class Timer : MonoBehaviour
{
    public static Timer Instance;

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

    public enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }

    public UnityEvent HitZero;

    public AudioSource OutOfTimeSound;

    public GameDifficulty Difficulty;

    public Text TimerText;

    public Text TimerTextLabel;

    public int EasyTime, MediumTime, HardTime;

    [HideInInspector]
    public int AllotedTime;

    private bool Playing;

    private void Start()
    {
        Playing = false;

        Difficulty = Saver.Instance.gameDifficulty;

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

        TimerText.text = AllotedTime.ToString() + " seconds left.";
        TimerTextLabel.text = Saver.Instance.Stats.PlayerName + "... You only have ";

        StartCoroutine(CountDownTimer());
    }

    IEnumerator CountDownTimer()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);

            AllotedTime -= 1;

            TimerText.text = AllotedTime.ToString() + " seconds left.";

            if(AllotedTime<=20 && !Playing)
            {
                OutOfTimeSound.Play();
                Playing = true;
            }

            if (AllotedTime <= 0)
            {
                HitZero?.Invoke();
            }
        }
    }

}
