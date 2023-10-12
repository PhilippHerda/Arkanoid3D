using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    public float lives;

    public Material yellow;
    public Material green;
    public GameObject powerUpPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Ball"))
        {
            lives -= 1;
            if (lives == 2)
            {
                GetComponent<MeshRenderer>().material = yellow;
            }
            else if (lives == 1)
            {
                GetComponent<MeshRenderer>().material = green;
            }
            else if (lives == 0)
            {
                Instantiate(powerUpPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
            }
        }
    }

    public void destroyYourself()
    {
        Destroy(gameObject);
    }
}
