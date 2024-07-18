using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Ship : MonoBehaviour
{
    private float velocity = 0f;
    private float shotInterval = .5f;
    private float cameraTopBound;
    private float cameraBottomBound;
    private float cameraLeftBound;
    private float cameraRightBound;

    [SerializeField] private Projectile projectile;
    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private float velocityDecaySpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float maxVelocity;


    void Start()
    {
        cameraLeftBound = Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect);
        cameraRightBound = Camera.main.transform.position.x + (Camera.main.orthographicSize * Camera.main.aspect);
        cameraBottomBound = Camera.main.transform.position.y - Camera.main.orthographicSize;
        cameraTopBound = Camera.main.transform.position.y + Camera.main.orthographicSize;
    }


    void Update()
    {
        MoveForward();
        if (Input.GetKey(KeyCode.UpArrow))
        {
            AddVelocity(velocityDecaySpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            AddVelocity(-velocityDecaySpeed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotate(rotationSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotate(-rotationSpeed);
        }
        if (Input.GetKey(KeyCode.Space) && shotInterval > .2f)
        {
            Projectile projectileShooted = Instantiate(projectile, projectileSpawnPoint.position, Quaternion.identity);
            projectileShooted.flyDirection = transform.up;
            shotInterval = 0f;
        }
        shotInterval += Time.deltaTime;

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

    private void Rotate(float rotationSpeed)
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void AddVelocity(float velocityDecaySpeed)
    {
        if (velocity < maxVelocity)
        {
            velocity += velocityDecaySpeed * Time.deltaTime *3f;
        }
    }

    private void MoveForward()
    {
        transform.position += Time.deltaTime * velocity * transform.up;
        if (velocity > 0f)
        {
            velocity -= Time.deltaTime * velocityDecaySpeed;
        }
        else
        {
            velocity = 0f;
        }
    }
}
