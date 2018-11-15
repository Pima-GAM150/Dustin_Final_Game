using UnityEngine;
using UnityEngine.Events;
public class InputListener : MonoBehaviour {

    public static InputListener Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    [HideInInspector]
    public UnityFloatEvent EventForward;

    [HideInInspector]
    public UnityFloatEvent EventRight;

    [HideInInspector]
    public UnityEvent EventJump;

    [HideInInspector]
    public UnityEvent EventEscape;

    [HideInInspector]
    public UnityEvent EventInteract;

    [HideInInspector]
    public UnityFloatEvent EventMouseX;

    [HideInInspector]
    public UnityFloatEvent EventMouseY;

    private bool _jumpPressed;
    private bool _escapePressed;
    private bool _interactPressed;

    private void Update()
    {
        BroadcastForward();
        BroadcastRight();
        BroadcastJump();


        BroadcastEscape();
        BroadcastInteract();

        BroadcastMouseX();
        BroadcastMouseY();
    }

    private void BroadcastInteract()
    {
        if (EventInteract == null) return;

        if (GetAxisDown("Interact", ref _interactPressed))
        {
            EventInteract.Invoke();
        }
    }

    private void BroadcastMouseY()
    {
        if (EventMouseY == null) return;

        var y = Input.GetAxis("Mouse Y");
        EventMouseY.Invoke(y);
    }

    private void BroadcastMouseX()
    {
        if (EventMouseX == null) return;

        var x = Input.GetAxis("Mouse X");
        EventMouseX.Invoke(x);
    }

    private void BroadcastEscape()
    {
        if (EventEscape == null) return;

        if (GetAxisDown("Cancel", ref _escapePressed))
        {
            EventEscape.Invoke();
        }
    }

    private void BroadcastForward()
    {
        if (EventForward == null) return;

        var fwd = Input.GetAxis("Vertical");
        EventForward.Invoke(fwd);
    }

    private void BroadcastJump()
    {
        if (EventJump == null) return;

        if (GetAxisDown("Jump", ref _jumpPressed))
        {
            EventJump.Invoke();
        }
    }

    private void BroadcastRight()
    {
        if (EventRight == null) return;

        var right = Input.GetAxis("Horizontal");
        EventRight.Invoke(right);
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
 * aswell as the layer movement script
 * 
 */