using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject Enemy;
    public GameObject EnemyM;
    public GameObject Totem;
    private Transform playerPos;
    private GameObject player;
    private bool dead = false;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(InstantiateEnemy());
    }
	
	// Update is called once per frame
	void Update () {
        //StartCoroutine(InstantiateEnemy());
	}

    public IEnumerator InstantiateEnemy() {
        while (true)
        {
            GameObject e = Instantiate(Enemy) as GameObject;
            Vector3 newPos = Random.insideUnitSphere * 100;

            e.transform.position = playerPos.position + newPos;
            yield return new WaitForSeconds(Random.Range(5.0f, 8.0f));

            GameObject M = Instantiate(EnemyM) as GameObject;
            newPos = Random.insideUnitSphere * 100;

            e.transform.position = playerPos.position + newPos;
            yield return new WaitForSeconds(Random.Range(5.0f, 8.0f));
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "PlayerWeapon" && dead == false)
        {
            GameObject e = Instantiate(Totem) as GameObject;
            Vector3 newPos = Random.insideUnitSphere * 100;

            e.transform.position = playerPos.position + newPos;
            newPos = e.transform.position;
            newPos.y = playerPos.position.y+3;
            e.transform.position = newPos;
            player.GetComponent<PlayerStats>().restore();
            Destroy(gameObject);

            dead = true;
        }
    }
}
