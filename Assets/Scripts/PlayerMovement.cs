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

    //player move speed (idk why it had to be changed to this high? player was moving incredibly slow for some reason)
    private float moveSpeed = 300f;

    //movement
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
        //Maintains player direction so W always moves forward
        Vector3 forward = transform.forward;
        Vector3 right = transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        //moves player
        Vector3 move = forward * MoveInput.y + right * MoveInput.x;
        controller.Move(move*moveSpeed*Time.deltaTime);

    }

    /// <summary>
    /// Read WASD inputs from playerInput
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }
}