using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float flySpeed = 10f;
    private float maxLifeTime = 1f;
    private float lifeTime = 0;
    private float cameraTopBound;
    private float cameraBottomBound;
    private float cameraLeftBound;
    private float cameraRightBound;

    public Vector3 flyDirection;

    private void Start()
    {
        cameraLeftBound = Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect);
        cameraRightBound = Camera.main.transform.position.x + (Camera.main.orthographicSize * Camera.main.aspect);
        cameraBottomBound = Camera.main.transform.position.y - Camera.main.orthographicSize;
        cameraTopBound = Camera.main.transform.position.y + Camera.main.orthographicSize;
    }

    void Update()
    {
        if (transform.position.x < cameraLeftBound)
        {
            transform.position = new Vector3(cameraRightBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > cameraRightBound)
        {
            transform.position = new Vector3(cameraLeftBound, transform.position.y, transform.position.z);
        }

        if (transform.position.y < cameraBottomBound)
        {
            transform.position = new Vector3(transform.position.x, cameraTopBound, transform.position.z);
        }
        else if (transform.position.y > cameraTopBound)
        {
            transform.position = new Vector3(transform.position.x, cameraBottomBound, transform.position.z);
        }
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
        {
            Destroy(gameObject);
        }
        Fly(flyDirection);
    }

    private void Fly(Vector3 flyDirection)
    {
        transform.position += flyDirection * Time.deltaTime * flySpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }
}
