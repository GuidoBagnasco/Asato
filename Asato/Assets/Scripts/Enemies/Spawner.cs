using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject EnemyS;
    public GameObject EnemyM;
    public GameObject Totem;
    public int maxPoolEnemyS = 0;
    public int maxPoolEnemyM = 0;
    public int maxPoolTotem = 0;
    private EnemyPool shooty;
    private EnemyPool melee;
    private EnemyPool totemSpawn;


    private void Awake() {
        shooty = new EnemyPool(EnemyS, maxPoolEnemyS);
        melee = new EnemyPool(EnemyM, maxPoolEnemyM);
        totemSpawn = new EnemyPool(Totem, maxPoolTotem);
    }


    public void InstantiateEnemy(EnemyType type, Transform playerPos, int amountToSpawn) {
        for (int i = 0; i < amountToSpawn; i++) {
            switch (type)  {
				case EnemyType.TOTEM:
					GameObject totem = totemSpawn.getPooledEnemy();
					Vector3 totemPos = Random.insideUnitSphere * 50;
					totemPos.y = 3;
					totem.transform.position = playerPos.position + totemPos;
					
					totem.SetActive(true);
					break;

				case EnemyType.MELEE:
                    GameObject mob = melee.getPooledEnemy();
                    Vector3 mobPos = Random.insideUnitSphere * 50;
                    mobPos.y = 0;
                    mob.transform.position = playerPos.position + mobPos;

                    mob.SetActive(true);
                    break;

				case EnemyType.SHOOTING:
					GameObject shooter = shooty.getPooledEnemy();
					Vector3 shooterPos = Random.insideUnitSphere * 50;
					shooterPos.y = 0;
					shooter.transform.position = playerPos.position + shooterPos;
					
					shooter.SetActive(true);
					break;
            }

        }
    
    }


	public void ReturnToList(GameObject enemy, EnemyType type) {
        switch (type) {
			case EnemyType.TOTEM:
				enemy.GetComponent<Totem>().RestoreStats();
				enemy.SetActive(false);
				totemSpawn.pooledEnemies.Add(enemy);
				break;

			case EnemyType.MELEE:
                enemy.SetActive(false);
                melee.pooledEnemies.Add(enemy);
                break;

			case EnemyType.SHOOTING:
				enemy.SetActive(false);
				shooty.pooledEnemies.Add(enemy);
				break;
        }
    }
}
