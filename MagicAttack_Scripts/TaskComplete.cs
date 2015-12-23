using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TaskComplete : MonoBehaviour {
	public GameObject task1;
	public GameObject task2;
	public GameObject task3;
	public GameObject task4;
	
	public GameObject laser;
	
	Energy coin;

	void Start () 
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		coin = player.GetComponent<Energy> ();
	}
	
	void Update () 
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		GameObject boss1 = GameObject.FindGameObjectWithTag ("Boss1");
		GameObject boss2 = GameObject.FindGameObjectWithTag ("Boss2");
		GameObject boss3 = GameObject.FindGameObjectWithTag ("Boss3");
		if (enemies.Length == 0 || enemies.Length == 1 && enemies[0].GetComponent<EnemyHealth>().startingHealth > 100) //no enemies
		{
			task1.GetComponent<Text>().color = Color.white;
		}
		
		if (enemies.Length == 0 && !boss1 && !boss2 && !boss3)
		{
			task2.GetComponent<Text>().color = Color.white;
		}
		if (boss1 || boss2 || boss3) 
		{
			task2.GetComponent<Text>().color = new Color32(122,111,111,111);
		}
		
		if (coin.currentcoins >= 200) 
		{
			task3.GetComponent<Text>().color = Color.white;
		}
		
		if (!laser.activeSelf) 
		{
			task4.GetComponent<Text>().color = Color.white;
		}
	}
}
