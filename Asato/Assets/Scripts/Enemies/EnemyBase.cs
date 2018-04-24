using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {
    protected GameObject player;
    protected EnemyStats stats;

    // Use this for initialization
    protected virtual void Start () {
        stats = this.GetComponent<EnemyStats>();
        player = GameObject.FindGameObjectWithTag("Player");
	}

    protected virtual void OnParticleCollision(GameObject other)
    {
        if (other.transform.tag == "ArmaPlayer")
        {
            stats.healthLoss(10); //valor daño de arma, el "10" es para que el codigo no chille
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "ArmaPlayer")
        {
            stats.healthLoss(10); //valor daño de arma, el "10" es para que el codigo no chille
        }
    }

}
