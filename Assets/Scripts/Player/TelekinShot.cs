using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelekinShot : MonoBehaviour
{
    public float Speed = 10;

	void Start ()
    {
        this.transform.forward = PlayerTelekin.PlayerS.GetComponentInChildren<Camera>().transform.forward;
	}

	void Update ()
    {
        transform.Translate(this.transform.forward * Speed * Time.deltaTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<ILiftable>().Lift();

        Destroy(this.gameObject);
    }
}
