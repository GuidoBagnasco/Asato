using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMob : EnemyBase {
    float stunTime = 0;


	protected override void OnStart() {
        type = EnemyType.MELEE;
    }


	private void Update() {
        stunTime += Time.deltaTime * Time.timeScale;

        switch (moveStyle) {
            case EnemyState.IDLE:
                if (stunTime >= 5) {
                    Vector3 newPos = RandomNavSphere(transform.position, 10, -1);
                    navigator.SetDestination(newPos);
                    stunTime = 0;
                }

                if (Vector3.Distance(transform.position, player.transform.position) < 70)
                    moveStyle = EnemyState.ATTACK;
                break;

            case EnemyState.ATTACK:
                if (Vector3.Distance(transform.position, player.transform.position) > 70) {
                    moveStyle = EnemyState.IDLE;
                    return;
                }
                if (stunTime >= 5)
                    moveTowardsPlayer();
                break;
        }

    }


    private void moveTowardsPlayer() {
        navigator.isStopped = false;
        navigator.SetDestination(player.transform.position);
    }


    private void OnCollisionEnter(Collision other) {
        if (other.transform.tag == "Player") {

            other.gameObject.GetComponent<Health>().Damage(stats.enemyDamage);
            stunTime = 0;
            navigator.isStopped = true;
        }
       
    }
}
