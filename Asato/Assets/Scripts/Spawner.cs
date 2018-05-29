using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject Enemy;
    private Transform playerPos;
	// Use this for initialization
	void Start () {
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
        }
    }
}
