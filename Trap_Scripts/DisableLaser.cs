using UnityEngine;
using System.Collections;

public class DisableLaser : MonoBehaviour {

	public GameObject DisLaser=null;
	public GameObject DisLaser1=null;
	public GameObject DisLaser2=null;
	public GameObject DisLaser3=null;
	
	void OnMouseDown(){
		
		DisLaser.SetActive (false);
		DisLaser1.SetActive (false);
		DisLaser2.SetActive (false);
		DisLaser3.SetActive (false);

	}
}
