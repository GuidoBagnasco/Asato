using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public int enemyHealth;
    public int enemyDamage;
	
	// Update is called once per frame
	public void healthLoss (int playerDamage) {
        enemyHealth -= playerDamage;
        if (enemyHealth <= 0)
            Destroy(this);
	}
}
