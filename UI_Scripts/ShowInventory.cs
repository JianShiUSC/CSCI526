using UnityEngine;
using System.Collections;

public class ShowInventory : MonoBehaviour 
{
	public GameObject inventory;
	bool showInventory = false;
	
	private void Start()
	{
//		inventory = GameObject.FindGameObjectWithTag ("Canvas");
		inventory.SetActive (false);
	}
	
	public void show()
	{
		showInventory = !showInventory;
		inventory.SetActive (showInventory);
		Pause_package ();
	}
	
	public void Pause_package()
	{
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}
}
