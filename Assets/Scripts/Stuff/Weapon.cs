using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = .1f;
    float fireTimer = 0;

    public GameObject projectile;

    public Transform emitTransform;

    void Start()
    {

    }


    void Update()
    {
    //    if (Input.GetMouseButtonDown(0))
    //    {

    //        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        //Vector3 direction = (point - transform.position).normalized;



    //    }
            fireTimer += Time.deltaTime;
    }

    public bool Fire(Vector3 position, Vector3 direction)
    {
        bool hasFired = false;

        if (fireTimer >= fireRate)
        {
            fireTimer = 0;
            GameObject b = Instantiate(projectile, position, Quaternion.identity);
            b.GetComponent<Projectile>().Fire(direction);
            hasFired = true;
        }

        return hasFired;
    }

    public bool Fire(Vector3 direction)
    {
        bool hasFired = false;

        if (fireTimer >= fireRate)
        {
            fireTimer = 0;
            GameObject b = Instantiate(projectile, emitTransform.position, emitTransform.rotation);
            b.GetComponent<Projectile>().Fire(direction);
            Destroy(b, 3);
            hasFired = true;
        }

        return hasFired;
    }
}
