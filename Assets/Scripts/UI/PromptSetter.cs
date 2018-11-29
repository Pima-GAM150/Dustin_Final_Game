using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PromptSetter : MonoBehaviour
{
    string Prompt;

    public Text PromptText;

    public Text PlaceHolderText;

    private void Start()
    {
        Loader.Instance.Load();
        int names = 0;
        bool NoNames = false;

        foreach (string s in Loader.Instance.Stats.PlayerName)
        {
            if (s == string.Empty)
            {
                names++;
            }
            if (names == 3)
            {
                NoNames = true;
            }
        }

        if (NoNames)
        {
            Prompt = "Hey, I don't recognize you... Whats your name? \n oh and dont forget to pick a dificulty.";
        }
        else
        {
            Prompt = "Hey, your name is "
                + Loader.Instance.Stats.LastPlayer +
                " right? If its not please change it.";

            PlaceHolderText.text = Loader.Instance.Stats.LastPlayer;
        }

        PromptText.text = Prompt;
    }
}
