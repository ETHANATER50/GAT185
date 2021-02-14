using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    float timer;
    Vector3 lastTargetLocation;

    public override void enter(Agent owner)
    {
        Debug.Log(GetType().Name + " enter");
    }

    public override void execute(Agent owner)
    {
        var gameObjects = owner.perception.getGameObjects();
        GameObject player = Perception.GetGameObjectFromTag(gameObjects, "Player");

        if (player == null)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                ((StateAgent)owner).stateMachine.setState("IdleState");
            }
        }

        lastTargetLocation = player.transform.position;
        timer = 1;
        owner.movement.MoveTowards(lastTargetLocation);
    }

    public override void exit(Agent owner)
    {
        Debug.Log(GetType().Name + " exit");
    }
}
