using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public float Speed = 10;
    public float Duration = 3;
    public float Damage = 5;

    private Vector3 Dir;
    
	void Start ()
    {
        StartCoroutine(LifeSpan());

        Dir = Player.PlayerS.Spawner.transform.forward;

    }

	void Update ()
    {
        transform.Translate( Dir * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<IDamagable>().TakeDamage(Damage);

        Destroy(this.gameObject);
    }
    private IEnumerator LifeSpan()
    {
        while (true)
        {
            yield return new WaitForSeconds(Duration);

            Destroy(this.gameObject);
        }
    }
}
