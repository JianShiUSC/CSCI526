using UnityEngine;
using System.Collections;

public class Trap2trigger : MonoBehaviour {
	
	
	public GameObject TrapEnemy;
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			TrapEnemy.SetActive(true);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			TrapEnemy.SetActive(false);
		}
	}
}
