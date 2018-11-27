using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player PlayerS;

    private void Awake()
    {
        if (PlayerS == null)
        {
            PlayerS = this;
        }
    }

    public GameObject Bullet;
    public GameObject Spawner;

    public void TelekinShot()
    {
        Instantiate(Bullet, Spawner.transform.position, Quaternion.identity);
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
