using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base of the finite state machine for Player movement
public class PlayerStateMachine : MonoBehaviour
{
    PlayerBaseState currentState;

    void Start()
    {
        currentState = GetInitialState();
        currentState.Enter();
    }

    void Update()
    {
        currentState.UpdateLogic();
    }

    void FixedUpdate()
    {
        currentState.UpdatePhysics();
    }

    protected virtual PlayerBaseState GetInitialState()
    {
        return null;
    }

    public void ChangeState(PlayerBaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        newState.Enter();
    }
}
