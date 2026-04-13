using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float sens = 20;
    private Vector2 mouseInput;
    private float pitch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //locks and removes cursor while player is walking around
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        //moves the camera with the mouse
        transform.Rotate(Vector3.up, mouseInput.x * sens * Time.deltaTime);
        pitch -= mouseInput.y * sens * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        transform.localEulerAngles = new Vector3(pitch, transform.localEulerAngles.y, 0f);
    }

    /// <summary>
    /// Mouse input moves camera
    /// </summary>
    /// <param name="context"></param>
    public void OnMouseMove(InputAction.CallbackContext context)
    {
        mouseInput = context.ReadValue<Vector2>();
    }
}
