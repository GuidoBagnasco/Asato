using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBase : MonoBehaviour {
    protected GameObject player;
    protected Vector3 playerPos;
    protected EnemyStats stats;
    protected NavMeshAgent navigator;
    protected Rigidbody rigidBody;


    // Use this for initialization
    protected virtual void Start () {
        stats = this.GetComponent<EnemyStats>();
        player = GameObject.FindGameObjectWithTag("Player");
       
        rigidBody = this.GetComponent<Rigidbody>();
        navigator = this.GetComponent<NavMeshAgent>();
    }

    protected virtual void OnParticleCollision(GameObject other)
    {
        if (other.transform.tag == "PlayerWeapon")
        {
            Debug.Log("ouch");
            Weapon w = other.GetComponentInParent<Weapon>();
            if (w != null) stats.healthLoss(w.dmg);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "PlayerWeapon")
        {
            Weapon w = other.GetComponent<Weapon>();
            if (w != null) stats.healthLoss(w.dmg);
        }
    }

}
