using UnityEngine;
using System.Collections;

public class Trap1Trigger : MonoBehaviour {

		public float TriggerForce = 22f;
		void OnTriggerStay(Collider other)
		{if (other.tag =="Trap1RB")
		other.GetComponent<Rigidbody>().AddForce (Vector3.up * TriggerForce, ForceMode.Acceleration);
		}

}
