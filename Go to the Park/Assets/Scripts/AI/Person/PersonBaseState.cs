using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base state used to inherate logic methods: hierachical 
public class PersonBaseState : MonoBehaviour
{
    protected PersonStateManager personStateManager;

    public PersonBaseState(PersonStateManager personStateManager)
    {
        this.personStateManager = personStateManager;
    }
    public virtual void Enter() {}
    public virtual void Update() {}
    public virtual void Exit() {}

}
