using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ThirdPersonRPG.Player
{
	public class PackageInfo: MonoBehaviour {
		public static PackageInfo packageInfo;

		public int[] SlotItemID;
		public int[] InventoryItemID;

		private int slotCount = 8;
		private int inventoryCount = 10;

		void Awake () {
			if (packageInfo == null) {		
				DontDestroyOnLoad (gameObject);
				packageInfo = this;
			} else if (packageInfo != this) {
				Destroy(gameObject);
			}
		}

		// Use this for initialization
		public void Start () {
			SlotItemID = new int[slotCount];
			InventoryItemID = new int[inventoryCount];
		}

		public void Save () {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (Application.persistentDataPath + "/PackageData.dat");
			
			PackageData data = new PackageData ();
			
			bf.Serialize (file, data);
			file.Close ();
		}

		public void Load () {
			if (File.Exists (Application.persistentDataPath + "/PackageData.dat")) {
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(Application.persistentDataPath + "/PackageData.dat", FileMode.Open);
				PackageData data = (PackageData)bf.Deserialize(file);
				file.Close();
				
				SlotItemID = data.SlotItemID;
				InventoryItemID = data.InventoryItemID;
			}
		}
	}

	[Serializable]
	class PackageData {
		public int[] SlotItemID;
		public int[] InventoryItemID;

		public PackageData () {
			SlotItemID = PackageInfo.packageInfo.SlotItemID;
			InventoryItemID = PackageInfo.packageInfo.InventoryItemID;
		}
	}
}
