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

        bool NoName = false;

        if (Loader.Instance.Stats.LastPlayer ==string.Empty)
        {
            NoName = true;
        }
        


        if (NoName)
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
