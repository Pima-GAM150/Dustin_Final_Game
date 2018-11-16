using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekinShot : MonoBehaviour
{
    public float Speed = 10;

	void Start ()
    {
		
	}

	void Update ()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
