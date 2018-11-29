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

    public AudioSource ShotSound;

    public GameObject PauseMenu;

    public void TelekinShot()
    {
        if (!PauseMenu.activeInHierarchy)
        {
            Instantiate(Bullet, Spawner.transform.position, Quaternion.identity);

            ShotSound.Play();
        }
        
    }

    Vector3 InitialPos;
    
    private void Start()
    {
        InputListener handle = InputListener.Instance;

        InitialPos = this.transform.position;

        handle.InteractWith.AddListener(TelekinShot);
    }

    private void OnDisable()
    {
        InputListener handle = InputListener.Instance;

        handle.InteractWith.RemoveListener(TelekinShot);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Respawn")
        {
            this.transform.position = InitialPos;
        }
    }
}
