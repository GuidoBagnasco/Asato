using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMob : EnemyBase
{
    float stunTime = 0;
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        type = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("stop" + navigator.isStopped);
        stunTime += Time.deltaTime * Time.timeScale;

        switch (moveStyle)
        {
            case enemyState.idle:
                if (stunTime >= 5)
                {
                    Vector3 newPos = RandomNavSphere(transform.position, 10, -1);
                    navigator.SetDestination(newPos);
                    stunTime = 0;
                }

                if (Vector3.Distance(transform.position, player.transform.position) < 70)
                    moveStyle = enemyState.attack;
                break;

            case enemyState.attack:
                if (Vector3.Distance(transform.position, player.transform.position) > 70)
                {
                    moveStyle = enemyState.idle;
                    return;
                }
                if (stunTime >= 5)
                    moveTowardsPlayer();
                break;
        }

    }

    void moveTowardsPlayer()
    {
        navigator.isStopped = false;
        navigator.SetDestination(player.transform.position);
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("fdf");
        if (other.transform.tag == "Player")
        {

            other.gameObject.GetComponent<Health>().Damage(stats.enemyDamage);
            stunTime = 0;
            navigator.isStopped = true;
        }
       
    }
}
