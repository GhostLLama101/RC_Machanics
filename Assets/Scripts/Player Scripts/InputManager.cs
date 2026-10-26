using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private PlayerInputs _playerInput;
    private PlayerInputs.OnFootActions onfoot;

    private PlayerMovement motor; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        
        _playerInput = new PlayerInputs();
        onfoot = _playerInput.OnFoot;
        motor = GetComponent<PlayerMovement>();

    }

    private void FixedUpdate()
    {
        // tell the player movement to move using the value form our movement action.
        motor.ProcessMove(onfoot.Movement.ReadValue<Vector2>());
    }

    void onEnable()
    {
        onfoot.Enable();
    }

    void onDisable()
    {
        onfoot.Disable();
    }
}
