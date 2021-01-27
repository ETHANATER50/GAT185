using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points = 100;
    public Material material;
    public GameObject destroyGameObject;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = material;
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Projectile"))
        {
            Game.Instance.addPoints(points);
            GetComponent<AudioSource>()?.Play();
            if (destroyGameObject != null)
            {
                Destroy(destroyGameObject);
            }
        }

    }

}
