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
    private int maxSpawn = 0;
    public enemyPool bla;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(InstantiateEnemy());
    }
	
	// Update is called once per frame
	void Update () {
    
	}

    public IEnumerator InstantiateEnemy() {
        while (maxSpawn<20)//Cambiar esto
        {
            GameObject e = bla.getPooledEnemy();
            Vector3 newPos = Random.insideUnitSphere * 50;
            newPos.y=0;
            e.transform.position = playerPos.position + newPos;

            e.SetActive(true);

            yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
        }
        maxSpawn++;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "PlayerWeapon" && dead == false)
        {
            GameObject e = Instantiate(Totem) as GameObject;
            Vector3 newPos = Random.insideUnitSphere * 50;

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
