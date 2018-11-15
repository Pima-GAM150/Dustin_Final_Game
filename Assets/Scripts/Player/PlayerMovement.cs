using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Vector3 Velocity;
    public Vector3 WishDirection;

    public float Dot;

    public float Gravity = 20.0f;
    public float JumpSpeed = 6.0f;
    public float MoveSpeed = 4.0f;

    public float GroundAcceleration = 15.0f;
    public float GroundDeceleration = 35.0f;

    public float AirAcceleration = 4.0f;
    public float AirDeceleration = 5.0f;

    public float CurrentSpeed;

    public bool Decelerating;

    public bool IsControlled;

    private struct Movement
    {
        public float Forward;
        public float Right;
        public bool Jump;
    }

    private struct MouseInput
    {
        public float Vertical;
        public float Horizontal;
    }

    private Movement movement;
    private MouseInput mouseInput;
    private CharacterController controller;

    private Transform playerCam;

    private void Start()
    {
        var cam = GetComponentInChildren<Camera>();
        if (cam == null)
        {
            Debug.LogError("No Camera found as child of object with PlayerMovement!");
        }
        else
        {
            playerCam = cam.transform;
        }

        controller = GetComponent<CharacterController>();

        Possess();
    }

    private void Update()
    {
        if (IsControlled)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        Vector3 wishDir = new Vector3(movement.Right, 0, movement.Forward).normalized;
        wishDir = transform.TransformDirection(wishDir);

        Vector3 lastVel = Velocity;
        lastVel.y = 0;
        
        Vector3 curDir = lastVel.normalized;

        float moveDot = Vector3.Dot(curDir, wishDir);
        Dot = moveDot;

        bool shouldAccelerate = (moveDot >= 0.01 || lastVel.sqrMagnitude <= 0.001f && wishDir.sqrMagnitude > 0);

        float vel;

        WishDirection = wishDir;

        if (controller.isGrounded)
        {
            vel = shouldAccelerate ? GroundAcceleration : GroundDeceleration;
        }
        else
        {
            vel = shouldAccelerate ? AirAcceleration : AirDeceleration;
        }

        if (shouldAccelerate)
        {
            wishDir *= vel * Time.deltaTime;
            lastVel += wishDir;
            Decelerating = false;
        }
        else
        {
            Decelerating = true;
            lastVel -= (curDir * vel) * Time.deltaTime;
        }

        lastVel = Vector3.ClampMagnitude(lastVel, MoveSpeed);

        if (lastVel.sqrMagnitude < 0.5 && !shouldAccelerate)
        {
            lastVel = Vector3.ClampMagnitude(lastVel, 0);
        }

        CurrentSpeed = Mathf.Abs(lastVel.magnitude);
        lastVel.y = Velocity.y;

        Velocity = lastVel;
        
        if (movement.Jump)
        {
            Velocity.y = JumpSpeed;
            movement.Jump = false;
        }
        else if (!controller.isGrounded)
        {
            Velocity.y -= Gravity * Time.deltaTime;
        }
        
        controller.Move(Velocity * Time.deltaTime);

        Vector3 rot = transform.eulerAngles;

        rot.y += mouseInput.Horizontal;

        transform.eulerAngles = rot;
    }

    private void LateUpdate()
    {
        Vector3 camRot = playerCam.transform.localEulerAngles;

        camRot.x += mouseInput.Vertical;

        playerCam.transform.localEulerAngles = camRot;
    }


    private void Vertical(float val)
    {
        if (Application.isFocused)
        {
            mouseInput.Vertical = val;
        }
        else
        {
            mouseInput.Vertical = 0;
        }
    }

    private void Horizontal(float val)
    {
        if (Application.isFocused)
        {
            mouseInput.Horizontal = val;
        }
        else
        {
            mouseInput.Horizontal = 0;
        }
    }

    private void Jump()
    {
        if (controller.isGrounded)
        {
            movement.Jump = true;
        }
    }

    private void MoveRight(float val)
    {
        movement.Right = val;
    }

    private void MoveForward(float val)
    {
        movement.Forward = val;
    }

    //subscribe to input events
    public void Possess()
    {
        var handle = InputListener.Instance;

        handle.ForwardPressed.AddListener(MoveForward);
        handle.RightPressed.AddListener(MoveRight);
        handle.JumpPressed.AddListener(Jump);
        handle.MouseXEvent.AddListener(Horizontal);
        handle.MouseYEvent.AddListener(Vertical);

        IsControlled = true;
    }

    //unsubscribe to input events
    public void Unpossess()
    {
        var handle = InputListener.Instance;

        handle.ForwardPressed.RemoveListener(MoveForward);
        handle.RightPressed.RemoveListener(MoveRight);
        handle.JumpPressed.RemoveListener(Jump);
        handle.MouseXEvent.RemoveListener(Horizontal);
        handle.MouseYEvent.RemoveListener(Vertical);

        IsControlled = false;
    }
}

/*
 * 
 * 
 * Much thanks to Andrew for this
 * 
 * 
 */
