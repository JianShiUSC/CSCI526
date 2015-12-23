using UnityEngine;
using System.Collections;

public class Trap5DisLaserBtn : MonoBehaviour {
	public GameObject HintArrow;
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Player") 
		{
			HintArrow.SetActive(true);

		}
	
	}
	void OnTriggerExit(Collider other) 
	{
		if (other.tag == "Player") 
		{
	
			HintArrow.SetActive(false);
			
		}
		
	}
}
