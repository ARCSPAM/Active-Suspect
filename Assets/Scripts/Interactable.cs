using UnityEngine;

/// <summary>
/// Interactable enums
/// </summary>
public enum InteractableType
{
    Computer,
    Door,
    Curtain,
    Window,
    Bed,
    HideSpot
}

/// <summary>
/// Attach this to an interactable with the correct enum
/// </summary>
public class Interactable : MonoBehaviour
{
    public InteractableType interactableType;
}