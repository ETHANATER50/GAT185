using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float healthMax;
    public float health;
    [Range(0, 10)] public float decay;
    public Slider slider;
    public GameObject destroySpawnObject;
    public bool destroyOnDeath = false;
    public bool isDead { get; set; }

    void Start()
    {
        health = healthMax;
    }

    void Update()
    {
        addHealth(-Time.deltaTime * decay);
        if (slider != null)
        {
            slider.value = health / healthMax;
        }

        if (health <= 0 && !isDead)
        {
            isDead = true;
            if(destroySpawnObject != null)
            {
                Instantiate(destroySpawnObject, transform.position, Quaternion.identity);
            }

            if (destroyOnDeath)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }

    public void addHealth(float change)
    {
        health += change;
        health = Mathf.Clamp(health, 0, healthMax);
    }
}
