using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour
{
    public float lives;

    public Material yellow;
    public Material green;
    public GameObject sizePowerUpPrefab;
    public GameObject slowDownPowerUpPrefab;

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
                int roll = Random.Range(0, 10);
                if (roll == 7 || roll == 8)
                {
                    Instantiate(sizePowerUpPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                }
                if (roll == 9)
                {
                    if (!GameLogic.slowDownEnabled)
                    {
                        Instantiate(slowDownPowerUpPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 90)));
                    }
                }
            }
            GameLogic.instance.Score();
        }
    }

    public void destroyYourself()
    {
        Destroy(gameObject);
    }
}
