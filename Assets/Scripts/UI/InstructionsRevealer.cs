using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsRevealer : MonoBehaviour
{
    public Text TextMat;

    public Material FunkyMat;

    public bool viewed = false;

    public void ChangeMaterial()
    {
        TextMat.material = TextMat.defaultMaterial;
    }

    private void OnEnable()
    {
        if (!viewed)
        {
            TextMat.material = FunkyMat;
            viewed = true;
        }
    }
}
