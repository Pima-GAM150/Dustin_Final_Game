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

    private Movement _movement;
    private MouseInput _mouseInput;
    private CharacterController _controller;

    private Transform _playerCam;

    private void Start()
    {
        var cam = GetComponentInChildren<Camera>();
        if (cam == null)
        {
            Debug.LogError("No Camera found as child of object with PlayerMovement!");
        }
        else
        {
            _playerCam = cam.transform;
        }

        _controller = GetComponent<CharacterController>();
        Possess();
    }

    private void Update()
    {
        if (IsControlled)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        var wishDir = new Vector3(_movement.Right, 0, _movement.Forward).normalized;
        wishDir = transform.TransformDirection(wishDir);
        var lastVel = Velocity;
        lastVel.y = 0;
        var curDir = lastVel.normalized;

        var moveDot = Vector3.Dot(curDir, wishDir);
        Dot = moveDot;
        var shouldAccelerate = (moveDot >= 0.01 || lastVel.sqrMagnitude <= 0.001f && wishDir.sqrMagnitude > 0);
        float vel;
        WishDirection = wishDir;

        if (_controller.isGrounded)
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
            lastVel = Vector3.ClampMagnitude(lastVel, 0);

        CurrentSpeed = Mathf.Abs(lastVel.magnitude);
        lastVel.y = Velocity.y;

        Velocity = lastVel;



        if (_movement.Jump)
        {
            Velocity.y = JumpSpeed;
            _movement.Jump = false;
        }

        else if (!_controller.isGrounded)
            Velocity.y -= Gravity * Time.deltaTime;



        _controller.Move(Velocity * Time.deltaTime);

        var rot = transform.eulerAngles;

        rot.y += _mouseInput.Horizontal;

        transform.eulerAngles = rot;
    }

    private void LateUpdate()
    {
        var camRot = _playerCam.transform.localEulerAngles;

        camRot.x += _mouseInput.Vertical;

        _playerCam.transform.localEulerAngles = camRot;
    }


    private void Vertical(float val)
    {
        if (Application.isFocused)
            _mouseInput.Vertical = val;
        else
            _mouseInput.Vertical = 0;
    }

    private void Horizontal(float val)
    {
        if (Application.isFocused)
            _mouseInput.Horizontal = val;
        else
            _mouseInput.Horizontal = 0;
    }

    private void Jump()
    {
        if (_controller.isGrounded)
        {
            _movement.Jump = true;
        }
    }

    private void MoveRight(float val)
    {
        _movement.Right = val;
    }

    private void MoveForward(float val)
    {
        _movement.Forward = val;
    }

    public void Possess()
    {
        var handle = InputListener.Instance;

        handle.EventForward.AddListener(MoveForward);
        handle.EventRight.AddListener(MoveRight);
        handle.EventJump.AddListener(Jump);
        handle.EventMouseX.AddListener(Horizontal);
        handle.EventMouseY.AddListener(Vertical);
        IsControlled = true;
    }
    public void Unpossess()
    {
        var handle = InputListener.Instance;
        handle.EventForward.RemoveListener(MoveForward);
        handle.EventRight.RemoveListener(MoveRight);
        handle.EventJump.RemoveListener(Jump);
        handle.EventMouseX.RemoveListener(Horizontal);
        handle.EventMouseY.RemoveListener(Vertical);
        IsControlled = false;
    }
}
