using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IDamagable
{    
    public float Health;

    void Update()
    {
        if(Health <= 0)
        {
            this.GetComponent<IDamagable>().Die();
        }
    }

    void IDamagable.TakeDamage(float damage)
    {
        Health -= damage;
    }

    void IDamagable.Die()
    {
        FindObjectOfType<Timer>().AllotedTime += 2;
        Destroy(this.gameObject);
    }
}
