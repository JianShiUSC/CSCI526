using UnityEngine;
using System.Collections;
namespace ThirdPersonRPG.Player{
	public class CollectWeapons  : MonoBehaviour {
		
		void OnTriggerEnter(Collider Others) {
			GameObject obj = Others.gameObject;
			if (obj.tag == "Player") {
				Energy eng = obj.GetComponent<Energy>();
				eng.collect_weapons(1);
			}
		}
		
	}
}