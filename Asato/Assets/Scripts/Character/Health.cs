using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	private static int HEALTH_MAX = 100;
	private int value = HEALTH_MAX;
	private HUD hud = null;
    private AudioSourcePlayer aSource;
    public AudioClip hit;
    public AudioClip death;

    private void Start () {
		hud = HUD.Instance as HUD;
        aSource = AudioSourcePlayer.Instance as AudioSourcePlayer;
	}


    public void Damage (int amount) {
		value = Mathf.Clamp (value - amount, 0, HEALTH_MAX);
        hud.UpdateElement(HUD.ElementType.HEALTH, value);

        if (value <= 0 && !GameController.Over) (GameController.Instance as GameController).GameOver();
	}


    protected virtual void OnParticleCollision(GameObject other) {
        if (other.transform.tag == "EnemyWeapon")
        {
            aSource.PlayOneShot (hit);
            Damage(other.GetComponentInParent<EnemyStats>().enemyDamage);
            hud.UpdateElement(HUD.ElementType.HEALTH, value);
        }

        if (value <= 0)
        {
            aSource.PlayOneShot (death);
            (GameController.Instance as GameController).GameOver();
        }
    }


    private void OnTriggerEnter(Collider other) {
        if (other.transform.tag == "EnemyWeapon")
        {
            aSource.PlayOneShot(hit);
            Damage(other.transform.GetComponentInParent<EnemyStats>().enemyDamage); //NO ME ARREPIENTO DE NADA
            hud.UpdateElement(HUD.ElementType.HEALTH, value);
        }

        if (other.transform.tag == "Loot")
        hud.UpdateElement(HUD.ElementType.HEALTH, value);

        if (value <= 0)
        {
            aSource.PlayOneShot(death);
            (GameController.Instance as GameController).GameOver();
        }
    }

}
