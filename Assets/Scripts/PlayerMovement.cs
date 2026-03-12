using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform camera;

    private float speed = 15f;
    private Rigidbody rb;
    private Vector2 moveInput;
    
    public InputActionReference playerMove;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //Vector3 move = camera.forward * moveInput.y + camera.right * moveInput.x;
        //move.y = 0f;
        //rb.AddForce(move.normalized * speed, ForceMode.VelocityChange);

        moveInput = playerMove.action.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if( context.performed)
        {
            //move code here
        }
    }
}