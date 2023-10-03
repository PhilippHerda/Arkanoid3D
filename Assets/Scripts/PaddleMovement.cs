using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;

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
}
