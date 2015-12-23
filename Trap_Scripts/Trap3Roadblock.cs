using UnityEngine;
using System.Collections;

namespace ThirdPersonRPG.Player{
public class Trap3Roadblock: MonoBehaviour {
	public GameObject Trap3Floor;
	public GameObject Trap3Roof;
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
			Trap3Floor.SetActive (true);
			Trap3Roof.SetActive (true);
		}
	}
}
}