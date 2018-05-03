using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	private static int HEALTH_MAX = 100;
	private int value = HEALTH_MAX;



    public void Damage (int amount) {
		value = Mathf.Clamp (value - amount, 0, HEALTH_MAX);
        HUD.Instance.UpdateText(HUD.TextType.HEALTH, value);

        if (value <= 0) HUD.Instance.GameOver();
	}

    public void addlife()
    {
        value += 80;
    }

    protected virtual void OnParticleCollision(GameObject other)
    {
        if (other.transform.tag == "EnemyWeapon")
        {
            Debug.Log("ouch");
            Damage(other.GetComponentInParent<EnemyStats>().enemyDamage);
        }
    }

}
