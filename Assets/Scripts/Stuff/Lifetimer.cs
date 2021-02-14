using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetimer : MonoBehaviour
{
    [Range(0, 60)] public float lifetime = 3;


    void Start()
    {
        GameObject.Destroy(gameObject, lifetime);
    }


}
