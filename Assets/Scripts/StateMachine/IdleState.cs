using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void enter(Agent owner)
    {
        Debug.Log(GetType().Name + " enter");
    }

    public override void execute(Agent owner)
    {
        SearchPath searchPath = owner.GetComponent<SearchPath>();
        searchPath.Move(owner.movement);

        var gameObjects = owner.perception.getGameObjects();
        GameObject player = Perception.GetGameObjectFromTag(gameObjects, "Player");


        if (player != null)
        {
            ((StateAgent)owner).stateMachine.setState("AttackState");
        }
    }

    public override void exit(Agent owner)
    {
        Debug.Log(GetType().Name + " exit");
    }
}
