using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base of the finite state machine for Player movement
public class PersonStateMachine : MonoBehaviour
{
    public PersonBaseState currentState;

    void Start()
    {
        currentState = GetInitialState();
        currentState.Enter();
    }

    void Update()
    {
        currentState.Update();
    }

    protected virtual PersonBaseState GetInitialState()
    {
        return null;
    }

    public void ChangeState(PersonBaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        newState.Enter();
    }
}
