using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, ILiftable, IDamagable
{
    private bool shootable;

    public float Health;

    public float MoveSpeed;

    void Start()
    {
        shootable = false;
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (shootable)
        {
            Launch();
        }
        else
        {
            MoveToPlayer();
        }
    }

    void ILiftable.Lift()
    {
        shootable = true;
    }

    void ILiftable.Shoot()
    {
        shootable = false;
    }

    void IDamagable.TakeDamage(float damage)
    {
        Health -= damage;
    }
    void IDamagable.Die()
    {
        Destroy(this.gameObject);
    }

    void Stop()
    {
        
    }

    void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(this.transform.position, PlayerTelekin.PlayerS.GetComponentInChildren<Camera>().transform.position, .1f);
    }

    void Launch()
    {
       
    }
}
