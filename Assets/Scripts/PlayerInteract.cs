using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    Camera playerCamera;

    //set maximum distance to interact with objects
    private float interactDistance = 3f;

    /// <summary>
    /// Will need to be updated to only allow interacting to happen when close to an object
    /// </summary>
    /// <param name="context"></param>
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            //go to computer mode until more interactables are added
        }
    }
}
