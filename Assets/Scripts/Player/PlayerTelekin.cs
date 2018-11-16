using UnityEngine;

public class PlayerTelekin : MonoBehaviour
{
    public GameObject Teleshot;
    public GameObject Catcher;

    void Shoot()
    {

    }
    void Lift()
    {

    }
    public void TelekinShot()
    {
        Instantiate(Teleshot,Catcher.transform.position,Teleshot.transform.rotation);
    }
}
