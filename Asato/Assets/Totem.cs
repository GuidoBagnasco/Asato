using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : EnemyBase {

    private int maxSpawn = 0;

    protected override void Start () {
        base.Start();
        navigator = null;
        type = 2;
        StartCoroutine("InstantiateEnemy");
    }
	
	// Update is called once per frame
	void Update () {
 
	}

    public void RestoreStats()
    {
        factory.InstantiateEnemy(2, player.transform, 1);
        player.GetComponent<PlayerStats>().restore();
    }
    public IEnumerator InstantiateEnemy()
    {
        while (maxSpawn<=10)
        {
            factory.InstantiateEnemy(0, player.transform, 1);
            factory.InstantiateEnemy(1, player.transform, 2);
            maxSpawn++;
            yield return new WaitForSeconds(Random.Range(5.0f, 8.0f));
        }   
    }
}