using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState {
    IDLE,
    ATTACK
}

public enum EnemyType {
	TOTEM,
	MELEE,
	SHOOTING,
    CHARGER
}

public class EnemyBase : MonoBehaviour {
    protected GameObject player;
    protected EnemyStats stats;
    protected NavMeshAgent navigator;
    protected Rigidbody rigidBody;
    protected EnemyState moveStyle = EnemyState.ATTACK;
    protected Spawner factory;
    protected List<GameObject> ownList = null;
    protected EnemyType type;
    public ParticleSystem blood;
    protected AudioSourcePlayer aSource;
    public AudioClip attack;
    public AudioClip death;
    public AudioClip hit;



	protected void Start () {
        factory = GameObject.Find("SpawnData").GetComponent<Spawner>();
        stats = this.GetComponent<EnemyStats>();
        player = GameObject.FindGameObjectWithTag("Player");
        rigidBody = this.GetComponent<Rigidbody>();
        navigator = this.GetComponent<NavMeshAgent>();
        aSource = AudioSourcePlayer.Instance as AudioSourcePlayer;
		OnStart ();
    }


	protected virtual void OnStart () {	}


    protected virtual void OnParticleCollision(GameObject other) {
        if (other.transform.tag == "PlayerWeapon") {
            Weapon gun = other.transform.parent.GetComponentInChildren<WeaponRange>();
            stats.HealthLoss(gun.dmg);
            aSource.PlayOneShot (hit);
            Emit();
        }
    }


    protected virtual void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "PlayerWeapon") {
            Weapon w = other.GetComponent<Weapon>();
            if (w != null) stats.HealthLoss(w.dmg);
            aSource.PlayOneShot (hit);
            Emit();
        }
    }

    protected virtual Vector3 RandomNavSphere (Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        UnityEngine.AI.NavMeshHit navHit;
        UnityEngine.AI.NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }


    public virtual void Recycle () {
        aSource.PlayAtPoint (death, transform.position);
        if (stats.enemyHealth < 1)
        {
            blood.Stop();
            factory.ReturnToList(gameObject, type);
        }
    }

    protected virtual void Emit()
    {
        if (type == 0)
        {
            blood.transform.position = new Vector3(gameObject.transform.position.x, blood.transform.position.y, gameObject.transform.position.z);
        }

        blood.Emit(10);
    }

    public void addList (List<GameObject> pooList){
        ownList = pooList;
    }

}
