﻿using UnityEngine;
using UnityEngine.UI;


public class EndingText : MonoBehaviour
{
    public Text Results;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (Saver.Instance.Stats.Score <= 0)
        {
            Results.text = "UhOh you didnt make it to the end in time...";
        }
        else
        {
            Results.text = "Yay you made it with " + Saver.Instance.Stats.Score + " seconds left on the clock.\n"
                + "Thats pretty good for playing on " + Saver.Instance.gameDifficulty.ToString();
        }
    }
}
