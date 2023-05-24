using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform PlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        FlipEnemy();
    }
    void FlipEnemy()
    {
        if (PlayerPosition.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (PlayerPosition.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
