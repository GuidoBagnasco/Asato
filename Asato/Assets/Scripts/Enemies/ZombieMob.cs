using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMob : EnemyBase {
    float stunTime = 0;
    // Use this for initialization
    protected override void Start()  {
        base.Start();
    }
	
	// Update is called once per frame
	void Update () {
        if (stunTime >= 0)
            stunTime -= Time.deltaTime * Time.timeScale;
        else
            moveTowardsPlayer();
        
    }

    void moveTowardsPlayer()
    {
        transform.LookAt(player.transform);
        navigator.SetDestination(playerPos);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.transform.tag == "Player")
        {
            ///player.healthLossPl(10); esto es placeholder
            stunTime = 2;
        }
    }
}
