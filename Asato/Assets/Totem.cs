using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : EnemyBase {

    private int maxSpawn = 0;

    protected override void OnStart () {
        navigator = null;
		type = EnemyType.TOTEM;
        StartCoroutine("InstantiateEnemy");
    }


    public void RestoreStats() {
		factory.InstantiateEnemy(type, player.transform, 1);
		player.GetComponent<MeiStats>().restore();
    }


    public IEnumerator InstantiateEnemy()  {
        while (maxSpawn <= 10) {
			factory.InstantiateEnemy(EnemyType.SHOOTING, player.transform, 1);
			factory.InstantiateEnemy(EnemyType.MELEE, player.transform, 2);
            maxSpawn++;
            yield return new WaitForSeconds(Random.Range(5.0f, 8.0f));
        }   
    }
}