using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMedium : Asteroid
{
    [SerializeField] Asteroid smallAsteroid;
    protected override void Split()
    {
        Instantiate(smallAsteroid, transform.position, Quaternion.identity);
        Instantiate(smallAsteroid, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
