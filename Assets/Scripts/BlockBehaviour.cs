using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    public float lives;

    public Material yellow;
    public Material green;

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
            // TODO: spawn powerup
        }
    }

    public void destroyYourself()
    {
        Destroy(gameObject);
    }
}
