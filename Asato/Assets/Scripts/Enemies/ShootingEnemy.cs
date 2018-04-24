using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : EnemyBase {
    float moveTimer = 2;
    protected ParticleSystem _balaE;
    // Use this for initialization

    protected override void Start() {
        base.Start();
        _balaE = GetComponentInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {


        if (moveTimer >= 0)
        {
            moveTimer -= Time.deltaTime * Time.timeScale;
            moveTowardsPlayer();
        }
        else
          Invoke("fire", 1);
    }

    void moveTowardsPlayer()
    {
        transform.LookAt(player.transform);
        transform.Translate(Vector3.forward * 1 * Time.deltaTime);
    }

    void fire()
    {
        _balaE.Emit(1);
        moveTimer = 2;
    }
}
