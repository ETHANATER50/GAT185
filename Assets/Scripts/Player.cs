using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2;

    public Weapon[] weapons;

    void Update()
    {

        //Vector3 velocity = Vector3.zero;


        //velocity.x = Input.GetAxis("Horizontal");
        //velocity.z = Input.GetAxis("Vertical");

        //if (Input.GetButtonDown("Jump")) velocity.y = 100;

        //transform.position += velocity * speed * Time.deltaTime;

        if (Input.GetButton("Fire1") && Game.Instance.state == Game.State.Game)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            weapons[0].Fire(ray.origin, ray.direction);
        }
    }
}
