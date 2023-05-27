using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public bool AttackInputRecieved;
    public bool AllowedToAttack;
    public bool PlayerIsAttacking;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckifAttackKeyPressed();
        DoAttacks();

    }
    void CheckifAttackKeyPressed()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (AllowedToAttack == true)
            {
                AttackInputRecieved = true;
            }
        }
    }

    void DoAttacks()
    {
        if (AttackInputRecieved == true)
        {
            if (PlayerIsAttacking == false)
            {
                anim.SetBool("Attack1", true);
                PlayerIsAttacking = true;
                AttackInputRecieved = false;
            }
        }
    }
    void firstAttackDone()
    {
        PlayerIsAttacking = false;
        anim.SetBool("Attack1", false);
    }
}
