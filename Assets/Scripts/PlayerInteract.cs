using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    Camera playerCamera;

    //set maximum distance to interact with objects
    private float interactDistance = 3f;

    //keeps track of the current object interacted with
    public IInteractable currentInteraction;

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
            //if the interact hits something, interact with it
            IInteractable interaction = hit.collider.GetComponent<IInteractable>();
            //pass the player into the interaction for necessary data
            interaction.Interact(gameObject);
            currentInteraction = interaction;
        }
    }
    /// <summary>
    /// Hitting escape to exit certain interactions
    /// </summary>
    /// <param name="context"></param>
    public void OnExitObject(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        //if in a valid state to exit from, exit
        currentInteraction.Exit(gameObject);
    }
}
