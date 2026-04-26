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

    public PlayerState GetPlayerState()
    {
        return playerState;
    }

    public void ChangeToState(PlayerState newState)
    {
        playerState = newState;
    }
}
