using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float Speed = 10;
    public float Damage = 5;
    
	void Start ()
    {
        this.transform.forward = Player.PlayerS.GetComponentInChildren<Camera>().transform.forward;
	}

	void Update ()
    {
        transform.Translate(this.transform.forward * Speed * Time.deltaTime);

        transform.Rotate(Vector3.up, Speed * Time.deltaTime);
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<IDamagable>().TakeDamage(Damage);

        Destroy(this.gameObject);
    }
}
