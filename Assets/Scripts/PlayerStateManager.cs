using TMPro.Examples;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Current Player State
/// </summary>
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

/// <summary>
/// Manages player state
/// </summary>
public class PlayerStateManager : MonoBehaviour
{
    //defaults to walking (change this to a start state for intro cutscene or something)
    public PlayerState playerState = PlayerState.Gaming;

    /// <summary>
    /// Returns current player state
    /// </summary>
    /// <returns></returns>
    public PlayerState GetPlayerState()
    {
        return playerState;
    }

    /// <summary>
    /// Sets current player state to passed in state
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeToState(PlayerState newState)
    {
        playerState = newState;
    }
}
