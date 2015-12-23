using UnityEngine;
using System.Collections;

public class door : MonoBehaviour {
	
	public GameObject thedoor;
	void OnTriggerEnter(Collider other)
	{
		
		thedoor.GetComponent<Animation>().Play("open");
	}
	void OnTriggerExit(Collider other)
	{
		thedoor.GetComponent<Animation>().Play("close");
	}
}
