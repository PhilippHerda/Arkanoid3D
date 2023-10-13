using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed;

    public GameObject playingField;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float max = playingField.transform.localScale.x * 10 * 0.5f - transform.localScale.x * 0.5f;

        float direction = Input.GetAxis("Horizontal");
        float newX = transform.position.x + direction * Time.deltaTime * speed;
        float clampedX = Mathf.Clamp(newX, -max, max);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("SizePowerUp"))
        {
            transform.localScale += new Vector3(1, 0, 0);
            other.gameObject.GetComponent<PowerUpBehaviour>().destroyYourself();
        }
        if (other.transform.CompareTag("SlowDownPowerUp"))
        {
            GameLogic.instance.EnableSlowDown();
            other.gameObject.GetComponent<PowerUpBehaviour>().destroyYourself();
        }
    }
}
