
using UnityEngine;
using System.Collections;
namespace ThirdPersonRPG.Player{
	public class CollectEnergy  : MonoBehaviour {
		
		void OnTriggerEnter(Collider Others) {
			GameObject obj = Others.gameObject;
			if (obj.tag == "Player") {
				Energy eng = obj.GetComponent<Energy>();
				eng.bottle2_energy(1);
			}
		}
		
	}
}