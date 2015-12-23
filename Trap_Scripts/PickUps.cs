using UnityEngine;
using System.Collections;

public class PickUps : MonoBehaviour 
{
	Inventory inventoryScripts;
	public GameObject inventory;

	void Start()
	{
		inventoryScripts = inventory.GetComponent<Inventory> ();
	}
	
	void OnTriggerEnter(Collider Others)
	{
		if (Others.gameObject.CompareTag("Pick Up"))
		{
			if(Others.gameObject.name != "goldCoins(Clone)")
			{
				inventoryScripts.addExistingItem(Others.gameObject.transform.GetComponent<DroppedItem>().item);
			}
			Destroy(Others.gameObject);
		}
	}
}
