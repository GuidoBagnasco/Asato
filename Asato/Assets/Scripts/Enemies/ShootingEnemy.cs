using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyBase {
    float moveTimer = 0;
    protected ParticleSystem _balaE;
    protected Quaternion neededRotation;
    protected bool aim = false;


    protected override void OnStart() {
        _balaE = GetComponentInChildren<ParticleSystem>();
        type = 0;
    }


	private void Update() {
        moveTimer += Time.deltaTime * Time.timeScale;
        Debug.Log(moveStyle);
        switch (moveStyle) {
            case EnemyState.IDLE:
                rigidBody.velocity = navigator.desiredVelocity;
                if (moveTimer > 3 && Vector3.Distance(transform.position, player.transform.position) < 70) {
                    navigator.isStopped = true;
                    moveTimer = 0;
                    moveStyle = EnemyState.ATTACK;
                }
                else if (moveTimer > 3 && Vector3.Distance(transform.position, player.transform.position) > 70)
                    move();
                break;

            case EnemyState.ATTACK:
                RaycastHit ICU;

                neededRotation = Quaternion.LookRotation(player.transform.position - transform.position);
                neededRotation.x = 0;
                neededRotation.z = 0;

                transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, Time.deltaTime * 100.0f);
                if (moveTimer < 1.5)
                {
                    if (Physics.Raycast(transform.position, transform.forward, out ICU) && ICU.transform.tag == "Player")
                    {
                        _balaE.Emit(1);
                        move();
                    }
                }
                else

                    move();
                break;
        }
    } 
    private void move()
    {
        moveStyle = EnemyState.IDLE;
        moveTimer = 0;
        navigator.isStopped = false;
        Vector3 newPos = RandomNavSphere(transform.position, 10, -1);
        navigator.SetDestination(newPos);

    }


}



