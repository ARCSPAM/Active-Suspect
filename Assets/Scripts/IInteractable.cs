using UnityEngine;

/// <summary>
/// Interactable interface
/// </summary>
public interface IInteractable
{
    void Interact(GameObject player);
    void Exit(GameObject player);

}