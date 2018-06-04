using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPool {
public List<GameObject> pooledEnemies = new List<GameObject>();
private GameObject enemies = null;
private int maxAmount;

    public EnemyPool(GameObject enemyPrefab, int maxSpawn) {
        enemies = enemyPrefab; 
        maxAmount = maxSpawn;
        for (int i = 0; i < maxAmount; i++)
        {
            pooledEnemies.Add(Create());
        }
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


	public GameObject Create() {
		GameObject enemy = GameObject.Instantiate(enemies) as GameObject;
        enemy.GetComponent<EnemyBase>().addList(pooledEnemies);
		enemy.SetActive(false);
		return enemy;
	}
}
