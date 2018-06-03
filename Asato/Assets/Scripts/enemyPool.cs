﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyPool : MonoBehaviour {
public List<GameObject> pooledEnemies;
private GameObject enemies = null;
private int maxAmount;

    public enemyPool(GameObject enemyPrefab, int maxSpawn)
    {
        enemies = enemyPrefab;
        pooledEnemies = new List<GameObject>();
        maxAmount = maxSpawn;
        for (int i = 0; i < maxAmount; i++)
        {
            pooledEnemies.Add(Create());
        }
    }
    // Use this for initialization
    void Awake () {


	}
	void Start () {

    }
	public GameObject getPooledEnemy() {
		GameObject go = null;

		if (pooledEnemies.Count > 0) {
			go = pooledEnemies[0];
			pooledEnemies.RemoveAt(0);
		}
		else 
			go = Create();

		return go;
	}

	public GameObject Create(){
		GameObject enemy = (GameObject) Instantiate(enemies);
        enemy.GetComponent<EnemyBase>().addList(pooledEnemies);
		enemy.SetActive(false);
		return enemy;
	}
}
