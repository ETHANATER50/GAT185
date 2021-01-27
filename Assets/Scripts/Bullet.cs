using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [Range(1, 100)] public float speed = 10;
    public AudioSource hitSound;
    public void Fire(Vector3 forward)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(forward * speed, ForceMode.VelocityChange);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            hitSound.Play();
        }
    }
}
