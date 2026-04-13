using TMPro.Examples;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    //Start,
    Gaming,
    Computer,
    //Hiding,
    //Sleeping,
    //Losing,
    //Winning
}
public class PlayerStateManager : MonoBehaviour
{
    public PlayerState playerState = PlayerState.Gaming;

    //might be temp? we'll need to stretch the camera to the computer screen or the computer screen to the camera
    public Transform computerViewPosition;

    //temp vars; we'll want to have an 'exit computer animation' thing so the camera doesn't just teleport back to the player
    private Vector3 playerStoredPosition;
    private Quaternion playerStoredRotation;

    /// <summary>
    /// Interact key pressed
    /// </summary>
    /// <param name="context"></param>
    public void OnInteract(InputAction.CallbackContext context)
    {
        if(!context.performed) return;
        if(context.performed)
        {
            //swap action map to computer mode
            gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("Computering");

            //store player position (temp) so camera returns to correct point
            playerStoredPosition = Camera.main.transform.position;
            playerStoredRotation = Camera.main.transform.rotation;

            //move camera to computer position and enable cursor
            Camera.main.transform.position = computerViewPosition.position;
            Camera.main.transform.rotation = computerViewPosition.rotation;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //disable mesh so can't see the player (temp)
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    /// <summary>
    /// Exiting the computer
    /// </summary>
    /// <param name="context"></param>
    public void OnExitComputer(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (context.performed)
        {
            //swap action map back to walking
            gameObject.GetComponent<PlayerInput>().SwitchCurrentActionMap("Gamering");

            //return camera to player position (temp)
            Camera.main.transform.position = playerStoredPosition;
            Camera.main.transform.rotation = playerStoredRotation;

            //Remove cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //enable mesh so player could be seen (by mirrors maybe? likely temp)
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
