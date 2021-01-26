using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnim : MonoBehaviour
{
    public GameObject destroyGameObject;

    public void destroyEvent(float time)
    {
        Destroy(destroyGameObject, time);
    }
}
