using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract void enter(Agent owner);
    public abstract void execute(Agent owner);
    public abstract void exit(Agent owner);
}
