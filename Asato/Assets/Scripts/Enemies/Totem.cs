using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : EnemyBase {
    private GameObject loot;
    private int maxSpawn = 0;

    protected override void OnStart () {
        navigator = null;
		type = EnemyType.TOTEM;
        StartCoroutine("InstantiateEnemy");
        blood = GameObject.Find("TotemEffect").GetComponent<ParticleSystem>();
        loot = GameObject.FindGameObjectWithTag("Loot");
    }


    public void RestoreStats() {
		factory.InstantiateEnemy(type, player.transform, 1);
        loot.transform.position = new Vector3(transform.position.x, loot.transform.position.y, transform.position.z);
        loot.GetComponent<Collider>().enabled = true;
        foreach (Renderer r in loot.GetComponentsInChildren(typeof(Renderer)))
        {
            r.enabled = true;
        }
    }


    public IEnumerator InstantiateEnemy()  {
        while (maxSpawn <= 10) {
			factory.InstantiateEnemy(EnemyType.SHOOTING,transform, 1);
			factory.InstantiateEnemy(EnemyType.MELEE, transform, 2);
            maxSpawn++;
            yield return new WaitForSeconds (Random.Range (10.0f, 18.0f));
        }   
    }
}