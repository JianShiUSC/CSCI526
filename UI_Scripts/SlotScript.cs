using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ThirdPersonRPG.Player
{
	public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler{
		
		public Item item;
		Image itemImage;
		public int slotNumber;
		Inventory inventory;
		GameObject player;
		PlayerHealth currentHealth;
		int startHealth;
		
		int draggedItemIndex;
		
		Text itemAmount;
		
		// Use this for initialization
		void Start () 
		{
			itemAmount = gameObject.transform.GetChild (1).GetComponent<Text> ();
			itemImage = gameObject.transform.GetChild (0).GetComponent<Image> ();
			player = GameObject.FindGameObjectWithTag ("Player");
			inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory>();
			startHealth = player.GetComponent<PlayerHealth> ().startingHealth;
			currentHealth = player.GetComponent<PlayerHealth> ();
		}
		
		// Update is called once per frame
		void Update ()
		{
			if (inventory.Items[slotNumber].itemName != null) 
			{
				itemAmount.enabled = false;
				item = inventory.Items[slotNumber];
				itemImage.enabled = true;
				itemImage.sprite = inventory.Items[slotNumber].itemIcon;
				
				if(inventory.Items[slotNumber].itemType == Item.ItemType.Consumable)
				{
					itemAmount.enabled = true;
					itemAmount.text = "" + inventory.Items[slotNumber].itemValue;
				}
			}
			else 
			{
				itemImage.enabled = false;
			}
			
			if (inventory.indexOfDraggedItem >= 0) {
				draggedItemIndex = inventory.indexOfDraggedItem;
			}
			
			if (Input.touchCount > 0) {
				var touch = Input.GetTouch(0);
				if(touch.phase ==  TouchPhase.Ended)
				{
					if(inventory.draggingItem)
					{
						//Debug.Log(inventory.indexOfDraggedItem);
						//if(inventory.indexOfDraggedItem >= 0)
						//{
						//inventory.Items[inventory.indexOfDraggedItem] = inventory.draggedItem;
						//inventory.closeDraggedItem();
						//}
						inventory.Items[draggedItemIndex] = inventory.draggedItem;
						inventory.closeDraggedItem();
					}
				}
			}
		}
		
		public void OnPointerDown(PointerEventData data)
		{
			inventory.closeTooltip ();
			if(inventory.Items[slotNumber].itemType == Item.ItemType.Consumable)
			{
				if(currentHealth.currentHealth == startHealth)
				{
					//the number of portion doesn't decrease,do nothing
				}
				else
				{
					if (currentHealth.currentHealth + inventory.Items[slotNumber].itemPower >= startHealth)
						currentHealth.currentHealth = startHealth;
					else
						currentHealth.currentHealth += inventory.Items[slotNumber].itemPower;
					inventory.Items[slotNumber].itemValue--;
				}
				
				if(inventory.Items[slotNumber].itemValue == 0)
				{
					inventory.Items[slotNumber] = new Item();
					itemAmount.enabled = false;
					inventory.closeTooltip();
				}
			}
			if(inventory.Items[slotNumber].itemName != null && !inventory.draggingItem)
			{
				inventory.showTooltip(inventory.Slots[slotNumber].GetComponent<RectTransform>().localPosition, inventory.Items[slotNumber]);
			}
		}
		
		public void OnPointerEnter(PointerEventData data)
		{
//			if (inventory.Items [slotNumber].itemName == null && inventory.draggingItem) {
//				inventory.Items [slotNumber] = inventory.draggedItem;
//				inventory.closeDraggedItem ();
//			}
//			else if(inventory.draggingItem && inventory.Items[slotNumber].itemName != null)
//			{
//				//Debug.Log("dragindex: " + inventory.indexOfDraggedItem);
//				inventory.Items[inventory.indexOfDraggedItem] = inventory.Items[slotNumber];
//				//Debug.Log("slot: " + slotNumber);
//				inventory.Items[slotNumber] = inventory.draggedItem;
//				inventory.closeDraggedItem();
//			}
		}
		
		public void OnPointerExit(PointerEventData data)
		{
			//if (inventory.Items [slotNumber].itemName != null) 
			//{
			//inventory.closeTooltip ();
			//}
			//Debug.Log ("exit");
		}
		
		public void OnDrag(PointerEventData data)
		{
			if (inventory.Items [slotNumber].itemType == Item.ItemType.Consumable) 
			{
//				inventory.Items[slotNumber].itemValue++;
			}
			
			if (inventory.Items [slotNumber].itemName != null) 
			{
				inventory.showDraggedItem(inventory.Items[slotNumber], slotNumber);
				inventory.Items[slotNumber] = new Item();
				itemAmount.enabled = false;
			}
		}
	}
}
