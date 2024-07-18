using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public abstract class Asteroid : MonoBehaviour
{
    private Vector3 randomMovementDirection;
    [SerializeField] float asteroidSpeed;
    private float cameraTopBound;
    private float cameraBottomBound;
    private float cameraLeftBound;
    private float cameraRightBound;

    void Start()
    {
        float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;

        randomMovementDirection = new Vector3(Mathf.Cos(randomAngle),Mathf.Sin(randomAngle),0);

        cameraLeftBound = Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect);
        cameraRightBound = Camera.main.transform.position.x + (Camera.main.orthographicSize * Camera.main.aspect);
        cameraBottomBound = Camera.main.transform.position.y - Camera.main.orthographicSize;
        cameraTopBound = Camera.main.transform.position.y + Camera.main.orthographicSize;

    }
    void Update()
    {
        transform.position += randomMovementDirection * Time.deltaTime * asteroidSpeed;

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

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            randomMovementDirection = new Vector3 (randomMovementDirection.y,randomMovementDirection.x,randomMovementDirection.z);
        }
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Split();
        }
    }

    protected virtual void Split()
    {
        
    }
}
