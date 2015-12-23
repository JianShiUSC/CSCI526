using UnityEngine;
using System.Collections;

namespace ThirdPersonRPG.Player
{
	public class EnemyMovement : MonoBehaviour 
	{
		Transform player;
		PlayerHealth playerHealth;
		EnemyHealth enemyHealth;
		NavMeshAgent nav;
		Animator anim;

		void Awake	()
		{
			player = GameObject.FindGameObjectWithTag ("Player").transform;
			playerHealth = player.GetComponent<PlayerHealth> ();
			enemyHealth = GetComponent<EnemyHealth> ();
			nav = GetComponent <NavMeshAgent> ();
		}

		void Update () 
		{
			if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && nav.enabled) 
			{
				nav.SetDestination (player.position);
			}
			else 
			{
				nav.enabled = false;
			}
		}

		void OnTriggerEnter (Collider others) 
		{
			GameObject obj = others.gameObject;
			if (obj.tag == "Player") 
			{
				anim = GetComponent<Animator> ();
				anim.SetBool ("Enter", true);
			}
		}
		
		void OnTriggerExit (Collider others) 
		{
//			random_num = -1;
//			Debug.Log (random_num);
			GameObject obj = others.gameObject;
			if (obj.tag == "Player") 
			{
				anim = GetComponent<Animator> ();
				anim.SetBool ("Enter", false);
//				anim.SetInteger("random_num", -1);
//				Debug.Log (random_num);
			}
		}
	}
}
