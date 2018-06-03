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
    private enemyPool shooty;
    private enemyPool melee;
    private enemyPool totemSpawn;

    private void Awake()
    {
        shooty = new enemyPool(EnemyS, maxPoolEnemyS);
        melee = new enemyPool(EnemyM, maxPoolEnemyM);
        totemSpawn = new enemyPool(Totem, maxPoolTotem);
    }

    public void InstantiateEnemy(int val, Transform playerPos, int amountToSpawn) {
        for (int i = 0; i < amountToSpawn; i++)
        {
            switch (val)
            {
                case 0:
                    GameObject shooter = shooty.getPooledEnemy();
                    Vector3 shooterPos = Random.insideUnitSphere * 50;
                    shooterPos.y = 0;
                    shooter.transform.position = playerPos.position + shooterPos;

                    shooter.SetActive(true);
                    break;

                case 1:
                    GameObject mob = melee.getPooledEnemy();
                    Vector3 mobPos = Random.insideUnitSphere * 50;
                    mobPos.y = 0;
                    mob.transform.position = playerPos.position + mobPos;

                    mob.SetActive(true);
                    break;

                case 2:
                    GameObject totem = totemSpawn.getPooledEnemy();
                    Vector3 totemPos = Random.insideUnitSphere * 50;
                    totemPos.y = 3;
                    totem.transform.position = playerPos.position + totemPos;

                    totem.SetActive(true);
                    break;
            }

        }
    
    }

    public void ReturnToList(GameObject enemy, int val)
    {
        switch (val)
        {
            case 0:
                enemy.SetActive(false);
                shooty.pooledEnemies.Add(enemy);
                break;

            case 1:
                enemy.SetActive(false);
                melee.pooledEnemies.Add(enemy);
                break;

            case 2:
                enemy.GetComponent<Totem>().RestoreStats();
                enemy.SetActive(false);
                totemSpawn.pooledEnemies.Add(enemy);
                break;
        }
    }
}
