using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSmall : Asteroid
{
    protected override void Split()
    {
        Destroy(gameObject);
    }
}
