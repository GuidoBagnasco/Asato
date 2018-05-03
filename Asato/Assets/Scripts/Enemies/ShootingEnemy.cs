using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyBase
{
    float moveTimer = 0;
    protected ParticleSystem _balaE;
    protected Quaternion neededRotation;
    protected bool aim = true;
    // Use this for initialization

    protected override void Start()
    {
        base.Start();
        _balaE = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(aim + "bla");
        moveTimer += Time.deltaTime * Time.timeScale;
        if (aim)
        {
            RaycastHit ICU;

            neededRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            neededRotation.x = 0;
            neededRotation.z = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, neededRotation, Time.deltaTime * 100.0f);
            if (moveTimer < 1.5)
            {
                Debug.Log(aim);

                if (Physics.Raycast(transform.position, transform.forward, out ICU) && ICU.transform.tag == "Player")
                {
                    Debug.Log("shoot");
                    _balaE.Emit(1);
                    move();
                }

            }
            else 

                move();
      

        }

        else
        {
            rigidBody.velocity = navigator.desiredVelocity;
            if (moveTimer > 2)
            {
                navigator.isStopped = true;
                moveTimer = 0;
                aim = true;
            }


        }

    }

    private void move()
    {
        aim = false;
        moveTimer = 0;
        navigator.isStopped = false;
        Vector3 newPos = RandomNavSphere(transform.position, 10, -1);
        navigator.SetDestination(newPos);
        Debug.Log("fdf");
    }
    
    private static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        UnityEngine.AI.NavMeshHit navHit;
        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}



