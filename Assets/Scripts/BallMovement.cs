using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Vector3 velocity;

    public float xMaxSpeed;
    public float zMaxSpeed;


    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(xMaxSpeed / 2, 0, -zMaxSpeed);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;

        // TODO: perhaps not the best place to implement this logic? (performance?)
        if (transform.position.z < -11)
        {
            GameLogic.instance.Death();
            destroyYourself();
        }
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
        else if (other.transform.CompareTag("Block"))
        {
            if (other.gameObject.GetComponent<BlockBehaviour>().lives == 1)
            {
                other.gameObject.GetComponent<BlockBehaviour>().destroyYourself();
            }
            velocity = new Vector3(velocity.x, velocity.y, -velocity.z);
        }
        if (!(other.transform.CompareTag("SizePowerUp") || other.transform.CompareTag("SlowDownPowerUp")))
        {
            audioSource.Play();
        }
    }

    void destroyYourself()
    {
        Destroy(gameObject);
    }
}
