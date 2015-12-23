using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using ThirdPersonRPG.Player;

public class MagicAttack : MonoBehaviour {
	public static int MagicAttack1DamagePerPeriod = 1;
	public static int MagicAttack2DamagePerPeriod = 2;
	public static int MagicAttack3DamagePerPeriod = 3;

	public static int Boss2FireStepPrintDamagePerPeriod = 3;	

	public static float timePeriod = 1f;

	private List<EnemyHealth> enemyHealthes = new List<EnemyHealth> ();
	
	public void OnTriggerEnter(Collider other) {
		EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth> ();
		PlayerHealth playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();

		enemyHealthes.Add (enemyHealth);

		if (enemyHealth && gameObject.tag == "MagicAttack1") enemyHealth.MagicAttack1 = true;
		if (enemyHealth && gameObject.tag == "MagicAttack2") enemyHealth.MagicAttack2 = true;
		if (enemyHealth && gameObject.tag == "MagicAttack3") enemyHealth.MagicAttack3 = true;

		if (playerHealth && gameObject.tag == "FireStepPrint") playerHealth.FirePrint = true;
	}

	public void OnTriggerExit(Collider other) {
		EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth> ();
		PlayerHealth playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();

		if (enemyHealth && gameObject.tag == "MagicAttack1") enemyHealth.MagicAttack1 = false;
		if (enemyHealth && gameObject.tag == "MagicAttack2") enemyHealth.MagicAttack2 = false;
		if (enemyHealth && gameObject.tag == "MagicAttack3") enemyHealth.MagicAttack3 = false;

		if (playerHealth && gameObject.tag == "FireStepPrint") playerHealth.FirePrint = false;
	}

	public void OnDestroy () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) {
			PlayerHealth playerHealth = player.GetComponent<PlayerHealth> ();
			if (playerHealth && gameObject.tag == "FireStepPrint") {
				playerHealth.FirePrint = false;
			}
		}

		foreach (EnemyHealth enemyHealth in enemyHealthes) {
			if (enemyHealth && gameObject.tag == "MagicAttack1") enemyHealth.MagicAttack1 = false;
			if (enemyHealth && gameObject.tag == "MagicAttack2") enemyHealth.MagicAttack2 = false;
			if (enemyHealth && gameObject.tag == "MagicAttack3") enemyHealth.MagicAttack3 = false;
		}
	}
}