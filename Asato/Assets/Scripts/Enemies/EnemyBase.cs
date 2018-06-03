using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum enemyState
{
    idle,
    attack
}
public class EnemyBase : MonoBehaviour {
    protected GameObject player;
    protected EnemyStats stats;
    protected NavMeshAgent navigator;
    protected Rigidbody rigidBody;
    protected enemyState moveStyle = enemyState.attack;
    protected Spawner factory;
    protected List<GameObject> ownList = null;
    protected int type;

    // Use this for initialization
    protected virtual void Start () {
        factory = GameObject.Find("SpawnData").GetComponent<Spawner>();
        stats = this.GetComponent<EnemyStats>();
        player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = this.GetComponent<Rigidbody>();
        navigator = this.GetComponent<NavMeshAgent>();
    }

    protected virtual void OnParticleCollision(GameObject other)
    {
        if (other.transform.tag == "PlayerWeapon")
        {
            Weapon w = other.GetComponentInParent<Weapon>();
            if (w != null) stats.healthLoss(w.dmg);
            Recycle();
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.tag == "PlayerWeapon")
        {
            Weapon w = other.GetComponent<Weapon>();
            if (w != null) stats.healthLoss(w.dmg);
            Recycle();
        }
    }

    protected virtual Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        UnityEngine.AI.NavMeshHit navHit;
        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    protected virtual void Recycle(){
        if (stats.enemyHealth <1)
            factory.ReturnToList(gameObject, type);      
    }

    public void addList (List<GameObject> pooList){
        ownList = pooList;
    }
}
