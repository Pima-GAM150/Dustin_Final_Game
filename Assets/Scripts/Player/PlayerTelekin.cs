using UnityEngine;

public class PlayerTelekin : MonoBehaviour
{
    public static PlayerTelekin PlayerS;

    private void Awake()
    {
        if (PlayerS == null)
        {
            PlayerS = this;
        }
    }
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
        Instantiate(Teleshot, PlayerTelekin.PlayerS.GetComponentInChildren<Camera>().transform.position, Teleshot.transform.rotation);
    }

    private void Start()
    {
        InputListener handle = InputListener.Instance;

        handle.InteractWith.AddListener(TelekinShot);
    }

    private void OnDisable()
    {
        InputListener handle = InputListener.Instance;

        handle.InteractWith.RemoveListener(TelekinShot);
    }
}
