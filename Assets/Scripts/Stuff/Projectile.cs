using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [Range(1, 100)] public float speed = 10;
    public AudioSource hitSound;
    public float lifespan = 1;
    public GameObject destroyfx;
    public bool destroyOnHit = false;

    private void Start()
    {
        Destroy(gameObject, lifespan);
    }

    private void OnDestroy()
    {
        Instantiate(destroyfx, transform.position, transform.rotation);
    }

    public void Fire(Vector3 forward)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(forward * speed, ForceMode.VelocityChange);
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Target"))
        //{
        //    hitSound.Play();
        //}

        if (destroyOnHit)
        {
            Destroy(gameObject);
        }
    }
}
