using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ChargeStates //NO USAR MAYUSCULAS esta escrito así adrede para diferenciar rapido de los estados ppales del enemigo
{
    Rage,
    Aim,
    Stun
}
public class Charger : EnemyBase
{
    ChargeStates cStates;
    float stunTime = 5;
    public Animator animator;
    float speed = 0;
    protected override void OnStart()
    {
        type = EnemyType.CHARGER;
        cStates = ChargeStates.Aim;
    }

    // Update is called once per frame
    private void Update()
    {
        stunTime += Time.deltaTime * Time.timeScale;

        switch (moveStyle)
        {
            case EnemyState.IDLE:


                if (stunTime >= 5)
                {
                    Vector3 newPos = RandomNavSphere(transform.position, 10, -1);
                    navigator.isStopped = false;
                    navigator.SetDestination(newPos);
                    animator.SetBool("walking", true);
                    stunTime = 0;
                }

                if (Vector3.Distance(transform.position, player.transform.position) < 70)
                {
                    moveTowardsPlayer();
                    if (Vector3.Distance(transform.position, player.transform.position) < 30)
                    {
                        navigator.isStopped = true;
                        moveStyle = EnemyState.ATTACK;
                        cStates = ChargeStates.Aim;
                        animator.SetBool("walking", false);

                    }

                }

                break;

            case EnemyState.ATTACK:
                if (Vector3.Distance(transform.position, player.transform.position) > 70)
                {

                    moveStyle = EnemyState.IDLE;
                    return;
                }
                switch (cStates)
                {
                    case ChargeStates.Rage:
                        animator.SetBool("attack", true);
                        transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        speed += 0.5f;
                        if (stunTime > 1)
                        {
                            speed = 0;
                            stunTime = 0;
                            animator.SetBool("attack", false);
                            cStates = ChargeStates.Stun;
                        }
                        break;

                    case ChargeStates.Aim:
                        transform.LookAt(player.transform.position);

                        RaycastHit ICU;

                        if (Physics.Raycast(transform.position, transform.forward, out ICU) && ICU.transform.tag == "Player")
                        {
                            stunTime = 0;
                            cStates = ChargeStates.Rage;
                            aSource.PlayOneShot(attack);
                        }

                        break;

                    case ChargeStates.Stun:
                        if (stunTime > 1)
                        {
                            stunTime = 0;
                            cStates = ChargeStates.Aim;
                        }

                        break;
                }

                break;
        }
    }


    private void moveTowardsPlayer()
    {
        navigator.isStopped = false;

        animator.SetBool("walking", true);
        navigator.SetDestination(player.transform.position);
    }


    private void OnCollisionEnter(Collision other)
    {

        if (other.transform.tag == "Player")
        {
            animator.SetBool("attack", false);
            animator.SetBool("walking", false);
            cStates = ChargeStates.Stun;
            stunTime = 0;

        }

    }
}