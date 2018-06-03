using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	private static int HEALTH_MAX = 100;
	private int value = HEALTH_MAX;
	private HUD hud = null;


	private void Start () {
		hud = HUD.Instance as HUD;
	}


    public void Damage (int amount) {
		value = Mathf.Clamp (value - amount, 0, HEALTH_MAX);
        hud.UpdateText(HUD.TextType.HEALTH, value);

        if (value <= 0) hud.GameOver();
	}


    protected virtual void OnParticleCollision(GameObject other) {
        if (other.transform.tag == "EnemyWeapon")  {
            Debug.Log("ouch");
            Damage(other.GetComponentInParent<EnemyStats>().enemyDamage);
        }
		(HUD.Instance as HUD).UpdateText(HUD.TextType.HEALTH, value);

		if (value <= 0) (HUD.Instance as HUD).GameOver();
	}


    public void addlife() {
        if (value < 100) {
            value = Mathf.Clamp(value + 80, 0, HEALTH_MAX);
			(HUD.Instance as HUD).UpdateText(HUD.TextType.HEALTH, value);
        }

    }

}
