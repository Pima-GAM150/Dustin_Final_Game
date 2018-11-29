using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerS : MonoBehaviour
{
    public static ManagerS Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
