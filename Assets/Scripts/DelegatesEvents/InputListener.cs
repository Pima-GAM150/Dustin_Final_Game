using UnityEngine;
using UnityEngine.Events;
public class InputListener : MonoBehaviour {

    public static InputListener Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        return;
    }

    [HideInInspector]
    public UnityFloatEvent ForwardPressed;

    [HideInInspector]
    public UnityEvent PausePressed;

    [HideInInspector]
    public UnityFloatEvent RightPressed;

    [HideInInspector]
    public UnityEvent JumpPressed;

    [HideInInspector]
    public UnityEvent EscapePressed;

    [HideInInspector]
    public UnityEvent InteractWith;

    [HideInInspector]
    public UnityFloatEvent MouseXEvent;

    [HideInInspector]
    public UnityFloatEvent MouseYEvent;

    private bool jumpPressed;
    private bool escapePressed;
    private bool interactPressed;
    private bool pausePressed;

    private void Update()
    {
        BroadcastForward();
        BroadcastRight();
        BroadcastJump();


        BroadcastEscape();
        BroadcastInteract();
        BroadcastPause();

        BroadcastMouseX();
        BroadcastMouseY();
    }

    private void BroadcastInteract()
    {
        if (InteractWith == null) return;

        if (GetAxisDown("Fire1", ref interactPressed))
        {
            InteractWith.Invoke();
        }
    }

    private void BroadcastMouseY()
    {
        if (MouseYEvent == null) return;

        float y = Input.GetAxis("Mouse Y");
        MouseYEvent.Invoke(-y);
    }

    private void BroadcastMouseX()
    {
        if (MouseXEvent == null) return;

        float x = Input.GetAxis("Mouse X");
        MouseXEvent.Invoke(x);
    }

    private void BroadcastEscape()
    {
        if (EscapePressed == null) return;

        if (GetAxisDown("Cancel", ref escapePressed))
        {
            EscapePressed.Invoke();
        }
    }

    private void BroadcastForward()
    {
        if (ForwardPressed == null) return;

        float fwd = Input.GetAxis("Vertical");
        ForwardPressed.Invoke(fwd);
    }

    private void BroadcastJump()
    {
        if (JumpPressed == null) return;

        if (GetAxisDown("Jump", ref jumpPressed))
        {
            JumpPressed.Invoke();
        }
    }
    private void BroadcastPause()
    {
        if (PausePressed == null) return;

        if (GetAxisDown("Pause", ref pausePressed))
        {
            PausePressed.Invoke();
        }
    }

    private void BroadcastRight()
    {
        if (RightPressed == null) return;

        float right = Input.GetAxis("Horizontal");
        RightPressed.Invoke(right);
    }

    private static bool GetAxisDown(string axis, ref bool isPressed)
    {
        if (!isPressed && Input.GetAxis(axis) > 0)
        {
            isPressed = true;
            return true;
        }

        if (Mathf.Abs(Input.GetAxis(axis)) < 1)
        {
            isPressed = false;
        }

        return false;
    }
}
/*
 * 
 * Much thanks to Andrew this is a good input controller
 * aswell as the player movement script
 * 
 */