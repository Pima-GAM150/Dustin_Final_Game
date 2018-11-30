using UnityEngine;
using UnityEngine.SceneManagement;

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

    public SingltonAccesser accesser;

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

        accesser.GoToEnding();
    }

    Vector3 InitialPos;
    
    private void Start()
    {
        InputListener handle = InputListener.Instance;
        Timer TimeHandle = Timer.Instance;

        InitialPos = this.transform.position;
        accesser = FindObjectOfType<SingltonAccesser>();

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

            if (SceneManager.GetActiveScene().name == "Level1")
            {
                accesser.Level2();
            }
            else if (SceneManager.GetActiveScene().name == "Leve2")
            {
                accesser.Level3();
            }
            else
            {
                accesser.GoToEnding();
            }
        }
    }
}
