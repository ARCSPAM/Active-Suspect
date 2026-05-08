using UnityEngine;
using UnityEngine.InputSystem;

public class ComputerInteract : MonoBehaviour, IInteractable
{
    //temp vars; we'll want to have an 'exit computer animation' thing so the camera doesn't just teleport back to the player
    private Vector3 playerStoredPosition;
    private Quaternion playerStoredRotation;

    //position for the camera to go to when in the computer
    public Transform computerViewPosition;

    /// <summary>
    /// Player interacts with computer
    /// </summary>
    /// <param name="player"></param>
    public void Interact(GameObject player)
    {
        //swap action map to computer mode
        player.GetComponent<PlayerInput>().SwitchCurrentActionMap("Computering");

        //store player position (temp) so camera returns to correct point
        playerStoredPosition = Camera.main.transform.position;
        playerStoredRotation = Camera.main.transform.rotation;

        //move camera to computer position and enable cursor
        Camera.main.transform.position = computerViewPosition.position;
        Camera.main.transform.rotation = computerViewPosition.rotation;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //disable mesh so can't see the player (temp)
        player.GetComponent<MeshRenderer>().enabled = false;

        player.GetComponent<PlayerStateManager>().ChangeToState(PlayerState.Gaming);
    }

    /// <summary>
    /// Player exits computer
    /// </summary>
    /// <param name="player"></param>
    public void Exit(GameObject player)
    {
        //swap action map back to walking
        player.GetComponent<PlayerInput>().SwitchCurrentActionMap("Gamering");

        //return camera to player position (temp)
        Camera.main.transform.position = playerStoredPosition;
        Camera.main.transform.rotation = playerStoredRotation;

        //Remove cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //enable mesh so player could be seen (by mirrors maybe? likely temp)
        player.GetComponent<MeshRenderer>().enabled = true;

        player.GetComponent<PlayerStateManager>().ChangeToState(PlayerState.Gaming);
    }
}
