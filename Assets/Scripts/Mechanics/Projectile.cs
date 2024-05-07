using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public float lifetime = 2.0f;
    public float speed = 10.0f;
    public Vector2 direction = Vector2.right;
    void Start()
    {
        if (lifetime <= 0) 
        {
            lifetime = 2.0f;
        }
        
        GetComponent<Rigidbody2D>().velocity = direction * speed;

        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log("Made Contact!");
        }
    }

    void update()
    {
        
    }
}

