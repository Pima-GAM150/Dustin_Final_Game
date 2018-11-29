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
        else
        {
            Destroy(this.gameObject);
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
    
    public void YouLoose()
    {
        Saver.Instance.SetScore(0);

        UIController.Instance.Ending();
    }

    Vector3 InitialPos;
    
    private void Start()
    {
        InputListener handle = InputListener.Instance;
        Timer TimeHandle = Timer.Instance;

        InitialPos = this.transform.position;

        TimeHandle.HitZero.AddListener(YouLoose);
        handle.InteractWith.AddListener(TelekinShot);

    }

    private void OnDisable()
    {
        InputListener handle = InputListener.Instance;
        Timer TimeHandle = Timer.Instance;

        TimeHandle.HitZero.AddListener(YouLoose);
        handle.InteractWith.RemoveListener(TelekinShot);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Respawn")
        {
            this.transform.position = InitialPos;
        }

        if(other.gameObject.tag == "Win")
        {
            Saver.Instance.SetScore(Timer.Instance.AllotedTime);

            UIController.Instance.Ending();
        }
    }
}
