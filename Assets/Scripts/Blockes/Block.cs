using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, ILiftable, IDamagable
{
    private bool shootable;

    public float Health;

    void Start()
    {

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

    }

    void ILiftable.Shoot()
    {

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

    }

    void Launch()
    {

    }
}
