using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public InputAction MousePosition;
    public InputAction MovePlayer;
    public InputAction Keystroke;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable() 
    {
        MovePlayer.Enable();
        MousePosition.Enable();
    }

    private void OnDisable() 
    {
        MovePlayer.Disable();
        MousePosition.Disable();
    }
        // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate() 
    {
        
    }
}
