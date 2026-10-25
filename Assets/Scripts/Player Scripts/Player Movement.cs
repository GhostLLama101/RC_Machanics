using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float Movement_X;

    public float Movement_Z; //{get; private set; }
    
    public float Jump_Y; //{get; private set; }

    public Rigidbody _rb; //{get; private set; }

    public float acceleration;

    public float turnrate;
    public float deadzone;

    private void Start()
    {
        //nothing right now
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement(_rb);
        HandleJump(_rb);
        HandleMouse(_rb);
    }

    void FixedUpdate()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // wasd controls
        //Debug.Log("OnMove");
        Vector2 movement = context.ReadValue<Vector2>();
        Movement_X = movement.x;
        Movement_Z = movement.y;
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log("OnJump");
        Vector2 movement = context.ReadValue<Vector2>();
        Jump_Y = movement.y;
    }
    
    // add the order to make the Ai go to that spot

    void HandleMovement(Rigidbody rb)
    {
        //rb.linearVelocity = new Vector3(Movement_X*acceleration, Jump_Y ,Movement_Z*acceleration);
        Vector3 move = (rb.transform.right * Movement_X + rb.transform.forward * Movement_Z) * acceleration;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
    }
    
    void HandleJump(Rigidbody rb)
    {
        Debug.Log("jumped");
    }
    // make this work for controllers aswell
    void HandleMouse(Rigidbody rb)
    {
        float dx = (Mouse.current.position.x.value - Screen.width / 2) / turnrate;
        if (Mathf.Abs(dx) > deadzone)
        {
            rb.transform.Rotate(0, dx, 0);
        }
    }
}
