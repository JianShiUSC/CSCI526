using UnityEngine;
using System.Collections;

namespace ThirdPersonRPG.Player
{
	public class EnemyAttack : MonoBehaviour 
	{
		public float timeBetweenAttacks = 0.5f;
		public int attackDamage;
		
		Animator anim;
		GameObject player;
		PlayerHealth playerHealth;
		EnemyHealth enemyHealth;
		bool playerInRange;
		float timer;
		int random_num = -1;
		
		PlayerAngryValue angryValue;
		
		
		void Awake()
		{
			player = GameObject.FindGameObjectWithTag ("Player");
			playerHealth = player.GetComponent<PlayerHealth> ();
			enemyHealth = GetComponent<EnemyHealth> ();
			anim = GetComponent <Animator> ();
			angryValue = player.GetComponent<PlayerAngryValue> ();
		}
		
		void OnTriggerEnter (Collider other)
		{
			if (other.gameObject == player) 
			{
				playerInRange = true;
				anim.SetInteger("random_num", random_num);
				//Debug.Log(random_num);
			}
		}
		void OnTriggerExit(Collider other)
		{
			if (other.gameObject == player) 
			{
				playerInRange = false;
			}
		}
		
		void Update()
		{
			timer += Time.deltaTime;
			
			if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) 
			{
				Attack();
			}
			
			if (playerHealth.currentHealth <= 0) 
			{
				anim.SetTrigger("PlayerDead");
			}
		}
		
		void Attack()
		{
			timer = 0f;
			random_num = Random.Range (0, 3);
			anim.SetInteger("random_num", random_num);
			//Debug.Log(random_num);
			if (playerHealth.currentHealth > 0) 
			{
				//Debug.Log(attackDamage);
				playerHealth.TakeDamage(attackDamage);
				angryValue.getAngryValue(attackDamage);
			}
		}
	}
}