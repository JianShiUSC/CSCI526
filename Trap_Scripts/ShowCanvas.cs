using UnityEngine;
using System.Collections;

public class ShowCanvas : MonoBehaviour {
	public GameObject CanvasBtn2;
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			CanvasBtn2.SetActive(true);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			CanvasBtn2.SetActive(false);
		}
	}
	
}