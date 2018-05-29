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
		SharedInstance = this;//Cambiar a generico
		pooledEnemies = new List<GameObject>();
		
		for (int i = 0; i < maxAmount; i++) {
			pooledEnemies.Add(Create());
		}

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
		enemy.SetActive(false);
		enemy
		return enemy;
	}
}
