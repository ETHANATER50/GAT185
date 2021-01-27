using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSpawner : MonoBehaviour
{
    public GameObject spawn;
    [Range(1,5)] public float lifetime = 5;
    public string tag;
    public bool useLifetime = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            GameObject gameObject = Instantiate(spawn, transform);
            if (useLifetime)
            {
                Destroy(gameObject, lifetime);
            }
        }
    }

}
