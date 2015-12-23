using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour 
{
	public List<Item> items = new List<Item>();

	// Use this for initialization
	void Awake () 
	{
		items.Add (new Item ("A_Armor04", 1, "Nice Armor", 10, 10, 1, Item.ItemType.Chest));//armor
		items.Add (new Item ("I_Antidote", 2, "Nice Drink", 10, 10, 1, Item.ItemType.Consumable));
		items.Add (new Item ("P_Blue02", 3, "Really nice Drink", 10, 10, 1, Item.ItemType.Consumable));
		items.Add (new Item ("C_Elm03", 4, "Helmet", 10, 10, 1, Item.ItemType.Head));//Head
		items.Add (new Item ("C_Hat01", 5, "Hat", 10, 10, 1, Item.ItemType.Head));//Head
		items.Add (new Item ("A_Shoes05", 6, "Speed Shoes", 10, 10, 1, Item.ItemType.Shoes));//Shoes
		items.Add (new Item ("Ac_Necklace01", 8, "BLA", 10, 10, 1, Item.ItemType.Necklace));
		items.Add (new Item ("Ac_Necklace02", 9, "BLA", 10, 10, 1, Item.ItemType.Necklace));
		
		items.Add (new Item ("W_Fist002", 11, "Chanllenger Gloves", 3, 10, 1, Item.ItemType.Hands));//Hands
		items.Add (new Item ("Ac_Ring04", 12, "Nice Ring", 10, 10, 1, Item.ItemType.Rings));
		
		items.Add (new Item ("W_Axe003", 13, "Double Axe", 10, 10, 1, Item.ItemType.Weapon));//double axes
		items.Add (new Item ("S_Sword05", 14, "Dark Sword", 10, 10, 1, Item.ItemType.Weapon));//dark sword
		items.Add (new Item ("W_Mace004", 15, "Mace", 10, 10, 1, Item.ItemType.Weapon));//mace
		items.Add (new Item ("W_Axe012", 16, "Skull Axe", 10, 10, 1, Item.ItemType.Weapon));//skull axe
		items.Add (new Item ("W_Mace011", 17, "Hammer", 10, 10, 1, Item.ItemType.Weapon));//hammer
		items.Add (new Item ("S_Sword10", 18, "Fantasy Sword", 10, 10, 1, Item.ItemType.Weapon));//fantasy sword
		items.Add (new Item ("S_Sword01", 19, "Elven Sword", 10, 10, 1, Item.ItemType.Weapon));//elven sword
	}
}
