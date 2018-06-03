using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyPool : MonoBehaviour {
public static enemyPool SharedInstance;
public List<GameObject> pooledEnemies;
private GameObject enemies;
public int maxAmount;

    public enemyPool(GameObject enemyPrefab)
    {
        enemies = enemyPrefab;
        pooledEnemies = new List<GameObject>();

    }
    // Use this for initialization
    void Awake () {


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
        enemy.GetComponent<EnemyBase>().addList(pooledEnemies);
		enemy.SetActive(false);
		return enemy;
	}
}
