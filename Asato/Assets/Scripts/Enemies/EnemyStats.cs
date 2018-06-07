using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

    public int enemyHealth;
    public int enemyDamage;
    public int scorePoints;
	private int baseHealth;

    private void Awake() {
        if (enemyHealth <= 0) Debug.LogWarning("Enemy " + name + " health equal or below 0!!!");
        if (enemyDamage <= 0) Debug.LogWarning("Enemy " + name + " damage equal or below 0!!!");
        if (scorePoints <= 0) Debug.LogWarning("Enemy " + name + " score equal or below 0!!!");
		baseHealth = enemyHealth;
    }


    public void healthLoss(int playerDamage) {
        enemyHealth -= playerDamage;
        if (enemyHealth <= 0)
		    (MeiStats.Instance as MeiStats).AddScore (scorePoints);
    }

	private void OnDisable() {
		enemyHealth = baseHealth;
	}
}
