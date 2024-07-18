using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBig : Asteroid
{
    [SerializeField] private GameObject mediumAsteroid;

    protected override void Split()
    {
        Instantiate(mediumAsteroid, transform.position, Quaternion.identity);
        Instantiate(mediumAsteroid, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
