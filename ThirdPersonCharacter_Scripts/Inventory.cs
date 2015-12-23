using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using ThirdPersonRPG.Player;

public class Inventory : MonoBehaviour 
{
	public List<GameObject> Slots = new List<GameObject> ();
	public List<Item> Items = new List<Item> ();
	public GameObject slots;
	ItemDatabase database;

	public int x= 103;
	public int y = -135;
	public int inventoryCount = 10;
	public GameObject tooltip;
	public GameObject draggedItemGameObject;
	public bool draggingItem = false;
	public Item draggedItem;
	public int indexOfDraggedItem;
	
	void Update()
	{
		if (draggingItem) 
		{
			Vector3 posi = (Input.mousePosition - GameObject.FindGameObjectWithTag("Canvas").GetComponent<RectTransform>().localPosition);
			draggedItemGameObject.GetComponent<RectTransform>().localPosition = new Vector3(posi.x + 15, posi.y-15, posi.z);
		}
	}

	public void UpdateInventory () {
		InitPackage ();
		for (int i = 0; i < inventoryCount; i++) {
			if (Items[i].itemType == Item.ItemType.None) {
				PackageInfo.packageInfo.InventoryItemID[i] = 0;
			}  else {
				PackageInfo.packageInfo.InventoryItemID[i] = Items[i].itemID;
			}
		}
	}
	
	public void showTooltip(Vector3 toolPosition, Item item)
	{
		tooltip.SetActive (true);
		tooltip.GetComponent<RectTransform> ().localPosition = new Vector3 (0.7f * toolPosition.x, 0.8f * toolPosition.y, toolPosition.z);
		tooltip.transform.GetChild (0).GetComponent<Text> ().text = item.itemName;
		tooltip.transform.GetChild (2).GetComponent<Text> ().text = item.itemDesc;
	}
	
	public void showDraggedItem(Item item, int slotnumber)
	{
		indexOfDraggedItem = slotnumber;
		closeTooltip ();
		draggedItemGameObject.SetActive (true);
		draggedItem = item;
		draggingItem = true;
		draggedItemGameObject.GetComponent<Image> ().sprite = item.itemIcon;
	}
	
	public void closeDraggedItem()
	{
		draggingItem = false;
		draggedItemGameObject.SetActive (false);
	}
	
	public void closeTooltip()
	{
		tooltip.SetActive (false);
	}

	public void Awake () {
		database = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDatabase> ();
	}
	
	// Use this for initialization
	
	public void checkIfItemExist(int itemID, Item item)
	{
		for (int i = 0; i < Items.Count; i++) 
		{
			if(Items[i].itemID == itemID)
			{
				Items[i].itemValue = Items[i].itemValue+ item.itemValue;
				break;
			}
			else if(i == Items.Count-1)
			{
				addItemAtEmptySlot(item);
			}
		}
	}
	
	public void addExistingItem(Item item)
	{
		if (item.itemType == Item.ItemType.Consumable) 
		{
			checkIfItemExist (item.itemID, item);
		}  
		else 
		{
			addItemAtEmptySlot(item);
		}
	}
	
	public void addItem(int id)
	{
		for (int i = 0; i < database.items.Count; i++) 
		{
			if(database.items[i].itemID == id)
			{
				Item item = database.items[i];
				
				if(database.items[i].itemType == Item.ItemType.Consumable)
				{
					checkIfItemExist(id, item);
					break;
				}
				else
				{
					addItemAtEmptySlot(item);
				}
			}
		}
	}
	
	void addItemAtEmptySlot(Item item)
	{
		//Debug.Log ("why");
		//Debug.Log (Items.Count);
//		InitPackage ();
		
		//Debug.Log (Items.Count);
		for (int i = 0; i < Items.Count; i++) 
		{
			if(Items[i].itemName == null)
			{
				Items[i] = item;
				break;
			}
		}
	}

	public void InitPackage () {
		int Slotamount = 0;
		if (Items.Count == 0) {
			for (int i = 1; i < 3; i++) {
				for (int k = 1; k < 6; k++) {
					GameObject slot = (GameObject)Instantiate (slots);
					slot.GetComponent<SlotScript> ().slotNumber = Slotamount;
					Slots.Add (slot);
					Items.Add (new Item ());
					slot.transform.parent = this.gameObject.transform;
					slot.name = "Slot" + i + "." + k;
					slot.GetComponent<RectTransform> ().localPosition = new Vector3 (x, y, 0);
					x = x + 115;
					if (k == 5) {
						x = 103;
						y = y - 115;
					}
					Slotamount++;
				}
			}

			for (int i = 0; i < inventoryCount; i++) {
				if (PackageInfo.packageInfo.InventoryItemID[i] != 0) {
					addItem(PackageInfo.packageInfo.InventoryItemID[i]);
				}
			}
		}
	}
}