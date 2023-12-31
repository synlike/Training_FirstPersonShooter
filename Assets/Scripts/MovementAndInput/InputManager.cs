using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private PlayerMovement movement;
    private PlayerLook look;
    private PlayerShoot shoot;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        movement = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();
        shoot = GetComponent<PlayerShoot>();

        onFoot.Jump.performed += _ => movement.Jump();
        onFoot.Crouch.performed += _ => movement.Crouch();
        onFoot.Crouch.canceled += _ => movement.Crouch();
        onFoot.Sprint.performed += _ => movement.Sprint();
        onFoot.Sprint.canceled += _ => movement.Sprint();
        onFoot.Fire.performed += _ => shoot.DoFire();
    }

    void FixedUpdate()
    {
        movement.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
