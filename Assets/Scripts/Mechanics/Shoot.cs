using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    SpriteRenderer sr;

    public Transform SpawnPointLeft;
    public Transform SpawnPointRight;
    public Projectile projectilePrefab;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Fire()
    {
        Transform spawnPoint = sr.flipX ? SpawnPointLeft : SpawnPointRight;
        Vector2 direction = sr.flipX ? Vector2.left : Vector2.right;

        Projectile curProjectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        curProjectile.direction = direction;
    }
}

