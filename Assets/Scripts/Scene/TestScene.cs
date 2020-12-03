using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene : MonoBehaviour
{

    private PlayerInput _playerInput;
    public SceneController sceneController;

    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if(_playerInput.Keystroke.ReadValue<float>()>0f)
        {
            
        }
    }
}
