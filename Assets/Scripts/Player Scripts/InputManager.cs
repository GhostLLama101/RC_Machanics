using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerInputs _playerInput;
    private PlayerInputs.OnFootActions onfoot;

    private PlayerMovement motor; 
    private PlayerLook look;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        
        _playerInput = new PlayerInputs();
        onfoot = _playerInput.OnFoot;
        
        motor = GetComponent<PlayerMovement>();
        look = GetComponent<PlayerLook>();
        
        onfoot.Jump.performed += ctx => motor.ProcessJump();

    }

    private void FixedUpdate()
    {
        // tell the player movement to move using the value form our movement action.
        motor.ProcessMove(onfoot.Movement.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
        look.ProcessLook(onfoot.Look.ReadValue<Vector2>());
    }
    void OnEnable()
    {
        onfoot.Enable();
    }

    void OnDisable()
    {
        onfoot.Disable();
    }
}
