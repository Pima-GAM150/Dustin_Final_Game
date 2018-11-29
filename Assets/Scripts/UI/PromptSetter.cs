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

        if (Loader.Instance.Stats.PlayerName == string.Empty)
        {
            Prompt = "Hey, I don't recognize you... Whats your name? \n oh and dont forget to pick a dificulty.";
        }
        else
        {
            Prompt = "Hey, your name is "
                + Loader.Instance.Stats.PlayerName +
                " right? If its not please change it.";

            PlaceHolderText.text = Loader.Instance.Stats.PlayerName;
        }

        PromptText.text = Prompt;
    }
}
