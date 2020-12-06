using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{

    public float Speed = 1f;

    private PhysicsBody _physicsBody;
    private Camera _playerCamera;
    private Renderer _renderer;
    private PlayerInput _playerInput;

    private Vector2 _moveLoc;
    private Vector2 _mouseLoc;
    private bool _playerIsMoving;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _physicsBody = GetComponentInChildren<PhysicsBody>();
        _renderer = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        if (_playerIsMoving)
        {
            _moveLoc = _mouseLoc;
        }
    }

    private void FixedUpdate()
    {
        Vector2 diff = _moveLoc - (Vector2)_physicsBody.transform.position;
        var vel = diff.normalized * Speed;
        if (diff.magnitude > vel.magnitude * Time.fixedDeltaTime)
        {
            _physicsBody.SetVelocity(vel);
        }
        else
        {
            _physicsBody.SetVelocity(Vector2.zero);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_moveLoc, 0.15f);
    }

#region Input Callback Functions
    public void onMousePosition(InputAction.CallbackContext context)
    {
        _mouseLoc = UnityEngine.Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    public void onMovePlayer(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            _playerIsMoving = true;
        }
        else if(context.canceled)
        {
            _playerIsMoving = false;
        }
    }

    public void onOpenGameMenu(InputAction.CallbackContext context)
    {
        if(context.action.triggered)
        {
            PageController pageController = PageController.instance;
            if(!pageController.PageIsOn(PageType.MENU))
            {
                pageController.TurnPageOn(PageType.MENU);
            }
            else
            {
                pageController.TurnPageOff(PageType.MENU);
            }
        }
    }
#endregion

}