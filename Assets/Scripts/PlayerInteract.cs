using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    Camera playerCamera;

    //set maximum distance to interact with objects
    private float interactDistance = 3f;

    //position for the camera to go to when in the computer
    public Transform computerViewPosition;

    //temp vars; we'll want to have an 'exit computer animation' thing so the camera doesn't just teleport back to the player
    private Vector3 playerStoredPosition;
    private Quaternion playerStoredRotation;

    /// <summary>
    /// Interacting with objects
    /// </summary>
    /// <param name="context"></param>
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        //cast short ray after hitting interact
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        //reacts to close object
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            //if the interact hits something, attempt to get its type
            InteractableType interaction = hit.collider.GetComponent<InteractableType>();
            if (interaction != null)
            {
                //test possible interaction objects
                switch(interaction)
                {
                    //upon interact with computer
                    case InteractableType.Computer:
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

                        gameObject.GetComponent<PlayerStateManager>().ChangeToState(PlayerState.Gaming);
                        break;
                    //if no option is found, exit
                    default:
                        break;
                }
            }
        }
    }
    /// <summary>
    /// Hitting escape to exit certain interactions
    /// </summary>
    /// <param name="context"></param>
    public void OnExitObject(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        //figure out which state player is in
        switch(gameObject.GetComponent<PlayerStateManager>().GetPlayerState())
        {
            //if player is in computer, exit back to walking
            case PlayerState.Computer:
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

                gameObject.GetComponent<PlayerStateManager>().ChangeToState(PlayerState.Gaming);
                break;
            //if player is not in a valid state to exit from, break
            default:
                break;
        }
    }
}
