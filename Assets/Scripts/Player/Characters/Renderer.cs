﻿using System.Collections;
using System.Collections.Generic;
using Steamworks;
using UnityEngine;
using Zenject;

public class Renderer : MonoBehaviour
{
    private PhysicsBody _physicsBody;
    private Animator _animator;
    private Vector2 _prevPos;
    private Vector2 _newPos;
    private float _deltaTime;
    private bool _posChanged = false;
    private PlayerCamera _camera;
    private CSteamID _owner;

    [Inject]
    public void Constructor(CSteamID owner, PlayerCamera camera, PhysicsBody physicsBody)
    {
        _owner = owner;
        _camera = camera;
        _physicsBody = physicsBody;
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("Test_Idle");
    }

    // Update is called once per frame
    void Update()
    {
        _animator.Play("Test_Running");
        if (_posChanged)
        {
            _prevPos = _newPos;
            _newPos = _physicsBody.transform.position;
            _deltaTime = 0f;
            _animator.SetFloat("x_vel", _newPos.x - _prevPos.x);
            _animator.SetFloat("y_vel", _newPos.y - _prevPos.y);
            _posChanged = false;
        }
        _deltaTime += Time.deltaTime;
        var elapsedTime = _deltaTime / Time.fixedDeltaTime;
        transform.position = Vector2.Lerp(_prevPos, _newPos, elapsedTime);
        if (_owner == SteamHelpers.Me)
        {
            _camera.SetPos(transform.position);
        }
    }

    private void FixedUpdate()
    {
        _posChanged = true;
    }
}
