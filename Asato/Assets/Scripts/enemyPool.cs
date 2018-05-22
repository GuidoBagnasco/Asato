using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyPool : MonoBehaviour {
public static enemyPool SharedInstance;
public List<GameObject> pooledEnemies;
public GameObject enemies;
public int maxAmount;
	// Use this for initialization
	void Awake () {
		SharedInstance = this;
		pooledEnemies = new List<GameObject>();
		for (int i = 0; i < maxAmount; i++){
			GameObject enemy = (GameObject) Instantiate(enemies);
			enemy.SetActive(false);
			pooledEnemies.Add(enemy);
		}
	}
	void Start () {

	}
	public GameObject getPooledEnemy() {
		for (int i = 0; i<pooledEnemies.Count;i++){
			if (!pooledEnemies[i].activeInHierarchy)
				return pooledEnemies[i];
		}
		return null;
	}
}
