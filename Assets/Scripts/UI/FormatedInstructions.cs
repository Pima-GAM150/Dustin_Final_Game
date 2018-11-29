using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FormatedInstructions : MonoBehaviour
{
    public Text Instructions;

    string path;
    string[] text;

    private void Start()
    {
        Instructions.text = SetInstructions();
    }

    public string SetInstructions()
    {
        string Result = "\n\n";
        path = Application.streamingAssetsPath + "/Instructions.txt";

        text = File.ReadAllLines(path);

        foreach(string s in text)
        {
            Result += "   " + s + "\n";
        }

        return Result;
    }
}
