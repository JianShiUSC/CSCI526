using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ThirdPersonRPG.Player
{
	public class CharacterSlot : MonoBehaviour , IPointerEnterHandler
	{
		public int index;
		public Item item;
		
		public GameObject Original;
		public GameObject DoubleAxe;
		public GameObject ElvenSword;
		public GameObject FantasySword;
		public GameObject DarkSword;
		public GameObject Hammer;
		public GameObject Mace;
		public GameObject SkullAxe;
		
		Inventory inventory;
		ItemDatabase itemDatabase;
		
		GameObject player;
		GameObject enemy1;
		PlayerHealth playerHealth;
		ThirdPersonCharacter v_multiplyer;
		Energy energy;

		bool start = true;

		public void InitCharacterSlot () {
			if (start) {
				if (index == 4) {
					Original.SetActive (true);
					DoubleAxe.SetActive (false);
					ElvenSword.SetActive (false);
					FantasySword.SetActive (false);
					DarkSword.SetActive (false);
					Hammer.SetActive (false);
					Mace.SetActive (false);
					SkullAxe.SetActive (false);
				}
			
				this.item = new Item ();
				foreach (Item item in itemDatabase.items) {
					if (PackageInfo.packageInfo.SlotItemID.Length > 0 && PackageInfo.packageInfo.SlotItemID [index] == item.itemID) {
						inventory.showDraggedItem (item, -1);
						OnPointerEnter (null);
						break;
					}
				}
				start = false;
			}
		}

		public void UpdateCharacterSlot () {
			InitCharacterSlot ();
			PackageInfo.packageInfo.SlotItemID [index] = item.itemID;
		}

		void Awake () {
			inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
			itemDatabase = GameObject.FindGameObjectWithTag ("ItemDatabase").GetComponent<ItemDatabase> ();
			player = GameObject.FindGameObjectWithTag ("Player");
			playerHealth = player.GetComponent<PlayerHealth> ();
			energy = player.GetComponent<Energy>();
			v_multiplyer = player.GetComponent<ThirdPersonCharacter> ();
		}
		
		void Update()
		{
			if (item.itemType != Item.ItemType.None) 
			{
				transform.GetChild (0).GetComponent<Image> ().enabled = true;
				transform.GetChild (0).GetComponent<Image> ().sprite = item.itemIcon;
			}
			else 
			{
				transform.GetChild(0).GetComponent<Image>().enabled = false;
			}

			//if (Input.touchCount > 0) {
			//var touch = Input.GetTouch(0);
			//if(touch.phase ==  TouchPhase.Ended)
			//{
			//if(inventory.draggingItem)
			//{
			////Debug.Log("drag");
			//inventory.Items[inventory.indexOfDraggedItem] = inventory.draggedItem;
			//inventory.closeDraggedItem();
			//}
			//}
			//}
		}
		
		public void Reset()
		{
			if (index == 0 && item.itemType == Item.ItemType.None) 
			{
				playerHealth.resistency_zombie -= (item.itemPower-1);//fire attribute
				playerHealth.resistency_fantasy -= (item.itemPower+1);//cold attribute
				playerHealth.resistency_alien -= (item.itemPower+2);//light attribute
			}
			if (index == 1 && item.itemType == Item.ItemType.None) 
			{
				playerHealth.resistency_zombie -= (item.itemPower);//fire attribute
				playerHealth.resistency_fantasy -= (item.itemPower+1);//cold attribute
				playerHealth.resistency_alien -= (item.itemPower-1);//light attribute
			}
			if (index == 2 && item.itemType == Item.ItemType.None) 
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetFloat("Floating", 0f);
			}
			if (index == 3 && item.itemType == Item.ItemType.None) 
			{
				
			}
			if (index == 4 && item.itemType == Item.ItemType.None) 
			{
				Original.SetActive (true);
				DoubleAxe.SetActive (false);
				ElvenSword.SetActive (false);
				FantasySword.SetActive (false);
				DarkSword.SetActive (false);
				Hammer.SetActive (false);
				Mace.SetActive (false);
				SkullAxe.SetActive (false);

				MagicAttack.MagicAttack3DamagePerPeriod -= item.itemPower;
				MagicAttack.MagicAttack2DamagePerPeriod -= (item.itemPower + 1);
				MagicAttack.MagicAttack1DamagePerPeriod -= (item.itemPower + 2);
			}
			if (index == 5 && item.itemType == Item.ItemType.None) 
			{
				
			}
			if (index == 6 && item.itemType == Item.ItemType.None) 
			{
				MagicAttack.MagicAttack3DamagePerPeriod -= item.itemPower;
				MagicAttack.MagicAttack2DamagePerPeriod -= item.itemPower + 1;
				MagicAttack.MagicAttack1DamagePerPeriod -= item.itemPower + 2;
			}
		}
		
		public void OnPointerEnter(PointerEventData data)
		{
			if (inventory.draggingItem) 
			{
				if(index == 0 && inventory.draggedItem.itemType == Item.ItemType.Head)///add all resistance
				{
					if(item.itemType != Item.ItemType.None)
					{
						Item temp = item;
						item = inventory.draggedItem;
						inventory.draggedItem = temp;
						inventory.showDraggedItem(temp, -1);
					}
					else
					{
						item = inventory.draggedItem;
						inventory.closeDraggedItem();
						
						playerHealth.resistency_zombie += (item.itemPower-1);//fire attribute
						playerHealth.resistency_fantasy += (item.itemPower+1);//cold attribute
						playerHealth.resistency_alien += (item.itemPower+2);//light attribute
					}
				}
				
				if(index == 1 && inventory.draggedItem.itemType == Item.ItemType.Chest)///add all resistance   
				{
					if(item.itemType != Item.ItemType.None)
					{
						Item temp = item;
						item = inventory.draggedItem;
						inventory.draggedItem = temp;
						inventory.showDraggedItem(temp, -1);
					}
					else
					{
						item = inventory.draggedItem;
						inventory.closeDraggedItem();
						playerHealth.resistency_zombie += (item.itemPower);//fire attribute
						playerHealth.resistency_fantasy += (item.itemPower+1);//cold attribute
						playerHealth.resistency_alien += (item.itemPower-1);//light attribute
					}
				}
				
				if(index == 2 && inventory.draggedItem.itemType == Item.ItemType.Shoes)///add velocity   factor*1.5
				{
					if(item.itemType != Item.ItemType.None)
					{
						Item temp = item;
						item = inventory.draggedItem;
						inventory.draggedItem = temp;
						inventory.showDraggedItem(temp, -1);
					}
					else
					{
						item = inventory.draggedItem;
						inventory.closeDraggedItem();
						GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetFloat("Floating", 1f);
					}
				}
				
				if(index == 3 && inventory.draggedItem.itemType == Item.ItemType.Rings)
				{
					if(item.itemType != Item.ItemType.None)
					{
						Item temp = item;
						item = inventory.draggedItem;
						inventory.draggedItem = temp;
						inventory.showDraggedItem(temp, -1);
					}
					else
					{
						item = inventory.draggedItem;
						inventory.closeDraggedItem();
						Debug.Log(item.itemName);
					}
				}
				
				if(index == 4 && inventory.draggedItem.itemType == Item.ItemType.Weapon)///add damage
				{
					if(item.itemType != Item.ItemType.None)//happen when alternate
					{
						Item temp = item;
						item = inventory.draggedItem;
						inventory.draggedItem = temp;
						inventory.showDraggedItem(temp, -1);
						
						MagicAttack.MagicAttack3DamagePerPeriod -= temp.itemPower;
						MagicAttack.MagicAttack2DamagePerPeriod -= (temp.itemPower + 1);
						MagicAttack.MagicAttack1DamagePerPeriod -= (temp.itemPower + 2);
						
						MagicAttack.MagicAttack3DamagePerPeriod += item.itemPower;
						MagicAttack.MagicAttack2DamagePerPeriod += (item.itemPower + 1);
						MagicAttack.MagicAttack1DamagePerPeriod += (item.itemPower + 2);
					}
					else
					{
						item = inventory.draggedItem;
						inventory.closeDraggedItem();

						MagicAttack.MagicAttack3DamagePerPeriod += item.itemPower;
						MagicAttack.MagicAttack2DamagePerPeriod += (item.itemPower + 1);
						MagicAttack.MagicAttack1DamagePerPeriod += (item.itemPower + 2);
					}

					if(item.itemID == 13)//doubleaxe
					{
						Original.SetActive(false);
						DoubleAxe.SetActive(true);
						ElvenSword.SetActive(false);
						FantasySword.SetActive(false);
						DarkSword.SetActive(false);
						Hammer.SetActive(false);
						Mace.SetActive(false);
						SkullAxe.SetActive(false);
					}
					else if(item.itemID == 19)//elven
					{
						Original.SetActive(false);
						DoubleAxe.SetActive(false);
						ElvenSword.SetActive(true);
						FantasySword.SetActive(false);
						DarkSword.SetActive(false);
						Hammer.SetActive(false);
						Mace.SetActive(false);
						SkullAxe.SetActive(false);
					}
					else if(item.itemID == 18)//fantasy
					{
						Original.SetActive(false);
						DoubleAxe.SetActive(false);
						ElvenSword.SetActive(false);
						FantasySword.SetActive(true);
						DarkSword.SetActive(false);
						Hammer.SetActive(false);
						Mace.SetActive(false);
						SkullAxe.SetActive(false);
					}
					else if(item.itemID == 14)//dark
					{
						Original.SetActive(false);
						DoubleAxe.SetActive(false);
						ElvenSword.SetActive(false);
						FantasySword.SetActive(false);
						DarkSword.SetActive(true);
						Hammer.SetActive(false);
						Mace.SetActive(false);
						SkullAxe.SetActive(false);
					}
					else if(item.itemID == 17)//hammer
					{
						Original.SetActive(false);
						DoubleAxe.SetActive(false);
						ElvenSword.SetActive(false);
						FantasySword.SetActive(false);
						DarkSword.SetActive(false);
						Hammer.SetActive(true);
						Mace.SetActive(false);
						SkullAxe.SetActive(false);
					}
					else if(item.itemID == 15)//mace
					{
						Original.SetActive(false);
						DoubleAxe.SetActive(false);
						ElvenSword.SetActive(false);
						FantasySword.SetActive(false);
						DarkSword.SetActive(false);
						Hammer.SetActive(false);
						Mace.SetActive(true);
						SkullAxe.SetActive(false);
					}
					else if(item.itemID == 16)//skull
					{
						Original.SetActive(false);
						DoubleAxe.SetActive(false);
						ElvenSword.SetActive(false);
						FantasySword.SetActive(false);
						DarkSword.SetActive(false);
						Hammer.SetActive(false);
						Mace.SetActive(false);
						SkullAxe.SetActive(true);
					}
				}
				
				if(index == 5 && inventory.draggedItem.itemType == Item.ItemType.Necklace)
				{
					if(item.itemType != Item.ItemType.None)
					{
						Item temp = item;
						item = inventory.draggedItem;
						inventory.draggedItem = temp;
						inventory.showDraggedItem(temp, -1);
					}
					else
					{
						item = inventory.draggedItem;
						inventory.closeDraggedItem();
						Debug.Log(item.itemName);
					}
				}
				
				if(index == 6 && inventory.draggedItem.itemType == Item.ItemType.Hands)///add damage
				{
					if(item.itemType != Item.ItemType.None)
					{
						Item temp = item;
						item = inventory.draggedItem;
						inventory.draggedItem = temp;
						inventory.showDraggedItem(temp, -1);
					}
					else
					{
						item = inventory.draggedItem;
						inventory.closeDraggedItem();
						
						MagicAttack.MagicAttack3DamagePerPeriod += item.itemPower;
						MagicAttack.MagicAttack2DamagePerPeriod += item.itemPower + 1;
						MagicAttack.MagicAttack1DamagePerPeriod += item.itemPower + 2;
					}
				}
				if(index == 7)
				{
					energy.collect_coins(inventory.draggedItem.itemSpeed);
					inventory.closeDraggedItem();
				}
			}
		}
		
		public void onDrag(PointerEventData data)
		{
			if (item.itemType != Item.ItemType.None) 
			{
				inventory.draggedItem = item;
				inventory.showDraggedItem(item, -1);
				item = new Item();
			}
		}
	}
}