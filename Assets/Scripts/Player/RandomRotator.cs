using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    private Vector3 RandomRotation;

    private void Start()
    {
        RandomRotation = new Vector3(Random.Range(8, 100), Random.Range(8, 100), Random.Range(8, 100));
    }
    void Update ()
    {
        transform.Rotate(RandomRotation, 1000 * Time.deltaTime);	
	}
}
