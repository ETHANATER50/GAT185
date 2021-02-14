using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State initialState;

    Dictionary<string, State> states = new Dictionary<string, State>();

    public Agent owner { get; set; }
    public State state { get; set; }

    void Start()
    {
        owner = GetComponent<Agent>();
        var cStates = GetComponents<State>();

        foreach(var state in cStates)
        {
            states.Add(state.GetType().Name, state);
        }

        setState(initialState);
    }

    public void execute()
    {
        state?.execute(owner);
    }

    public void setState(string stateName)
    {
        if (states.ContainsKey(stateName))
        {
            setState(states[stateName]);
        }
    }

    public void setState(State newState)
    {
        if(newState != state)
        {
            state?.exit(owner);
            state = newState;
            newState.enter(owner);
        }
    }

}
