using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRotator : MonoBehaviour
{
    public float RotationSpeed = 10;
    private void Update ()
    {
        transform.Rotate(new Vector3(0,RotationSpeed * Time.deltaTime,0));
	}
}
