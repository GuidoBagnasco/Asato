using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject EnemyS;
    public GameObject EnemyM;
    public GameObject Totem;
    public GameObject EnemyC;
    public int maxPoolEnemyS = 0;
    public int maxPoolEnemyM = 0;
    public int maxPoolTotem = 0;
    public int maxPoolEnemyC = 0;
    public List<Transform> TotemPosition;
    private EnemyPool shooty;
    private EnemyPool melee;
    private EnemyPool charger;
    private EnemyPool totemSpawn;


    private void Awake() {
        shooty = new EnemyPool(EnemyS, maxPoolEnemyS);
        melee = new EnemyPool(EnemyM, maxPoolEnemyM);
        totemSpawn = new EnemyPool(Totem, maxPoolTotem);
        charger = new EnemyPool(EnemyC, maxPoolEnemyC);
    }


    public void InstantiateEnemy(EnemyType type, Transform origPos, int amountToSpawn) {
        for (int i = 0; i < amountToSpawn; i++) {
            switch (type)  {
				case EnemyType.TOTEM:
					GameObject totem = totemSpawn.getPooledEnemy();
                    do
                    {
                        totem.transform.position = TotemPosition[Random.Range(0, 3)].position;
                    } while (totem.transform.position == origPos.position);
                     
					
					totem.SetActive(true);
					break;

				case EnemyType.MELEE:
                    GameObject mob = melee.getPooledEnemy();
                    Vector3 mobPos = Random.insideUnitSphere * 50;
                    mobPos.y = 0;
                    mob.transform.position = origPos.position + mobPos;

                    mob.SetActive(true);
                    break;

				case EnemyType.SHOOTING:
					GameObject shooter = shooty.getPooledEnemy();
					Vector3 shooterPos = Random.insideUnitSphere * 50;
					shooterPos.y = 0;
					shooter.transform.position = origPos.position + shooterPos;
					
					shooter.SetActive(true);
					break;


                case EnemyType.CHARGER:
                    GameObject chargerE = charger.getPooledEnemy();
                    Vector3 chargerPos = Random.insideUnitSphere * 50;
                    chargerPos.y = 0;
                    chargerE.transform.position = origPos.position + chargerPos;

                    chargerE.SetActive(true);
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

            case EnemyType.CHARGER:
                enemy.SetActive(false);
                charger.pooledEnemies.Add(enemy);
                break;
        }
    }
}
