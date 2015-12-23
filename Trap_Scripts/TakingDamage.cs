using UnityEngine;
using System.Collections;

namespace ThirdPersonRPG.Player{
	public class TakingDamage : MonoBehaviour 
	{
		void OnCollisionEnter(Collision other)
		{
			GameObject obj = other.gameObject;
			if(obj.tag == "Player")
			{
				PlayerHealth ph = obj.GetComponent<PlayerHealth>();
				ph.TakeDamage(30);
			}
		}
	}
}