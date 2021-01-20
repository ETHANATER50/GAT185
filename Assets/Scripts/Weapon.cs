using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = .1f;
    int ammo = 100;
    float fireTimer = 0;

    public GameObject bullet;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fireTimer += Time.deltaTime;

            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vector3 direction = (point - transform.position).normalized;



        }
    }

    public bool Fire(Vector3 position, Vector3 direction)
    {
        bool hasFired = false;

        if (fireTimer >= fireRate)
        {
            fireTimer = 0;
            GameObject b = Instantiate(bullet, position, Quaternion.identity);
            b.GetComponent<Bullet>().Fire(direction);
            Destroy(b, 3);
            hasFired = true;
        }

        return hasFired;
    }
}
