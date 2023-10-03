using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Vector3 velocity;

    public float xMaxSpeed;
    public float zMaxSpeed;

    // public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(xMaxSpeed / 2, 0, -zMaxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Paddle"))
        {
            GameObject paddle = other.gameObject;

            float maxDist = paddle.transform.localScale.x * 0.5f + transform.localScale.x * 0.5f;
            float dist = transform.position.x - paddle.transform.position.x;
            float normalizedDist = dist / maxDist;

            velocity = new Vector3(normalizedDist * zMaxSpeed, velocity.y, -velocity.z);
        }
        else if (other.transform.CompareTag("Wall"))
        {
            velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
        }
        else if (other.transform.CompareTag("Ceiling"))
        {
            velocity = new Vector3(velocity.x, velocity.y, -velocity.z);
        }
        // audioSource.Play();
    }
}
