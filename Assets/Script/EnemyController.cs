using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform PlayerPosition;
    public float CurrentEnemyHeath = 100f;
    public Animator EnemyAnim;
    public GameObject FireballGO;
    public float minimumFiringDistance;
    public float CalculatedTime;
    public float TimeBtwEachShoot;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyAnim = GetComponent<Animator>();
        CalculatedTime = TimeBtwEachShoot;
    }

    // Update is called once per frame
    void Update()
    {
        FlipEnemy();
        FireballMechanis();
    }
    void FireballMechanis()
    {
        if (Vector2.Distance(transform.position, PlayerPosition.position) <= minimumFiringDistance)
            if (CalculatedTime <= 0)
            {
                EnemyAnim.SetBool("EnemyAttack", true);
                Instantiate(FireballGO, transform.position, Quaternion.LookRotation(Vector3.forward, transform.position - PlayerPosition.position));
                CalculatedTime = TimeBtwEachShoot;
            }
            else
            {
                CalculatedTime -= Time.deltaTime;
                EnemyAnim.SetBool("EnemyAttack", false);
            }
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
    public virtual void DamageEnemy(float damageAmount)
    {
        CurrentEnemyHeath -= damageAmount;
    }
}
