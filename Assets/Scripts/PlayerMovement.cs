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
    public float moveSpeed = 5f;

    //move
    private Vector2 MoveInput;
    private CharacterController controller;

    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        //Move code
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
        Vector3 move = forward * MoveInput.y + right * MoveInput.x;
        //Vector3 move = new Vector3(MoveInput.x,0,MoveInput.y);
        controller.Move(move*moveSpeed*Time.deltaTime);

    }

    //read WASD inputs from playerInput
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }
}