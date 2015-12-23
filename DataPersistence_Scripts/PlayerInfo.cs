using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ThirdPersonRPG.Player
{
	public class PlayerInfo : MonoBehaviour {

		public static PlayerInfo playerinfo;

		public int health;
		public string scene;
		public Vector3 position;
		public int experienceVal;
		public int currentLevel;

		public bool load;

		// Use this for initialization
		void Awake () {
			if (playerinfo == null) {
				DontDestroyOnLoad (gameObject);
				playerinfo = this;
			} else if (playerinfo != this) {
				Destroy(gameObject);
			}
		}

		public void Start (){
			health = 500;
			currentLevel = 1;
			experienceVal = 0;
			scene = "";
			position = Vector3.zero;
			load = false;
		}

//		void OnGUI() {
//			GUI.Label (new Rect (10, 10, 500, 30), "Health: " + health);
//			GUI.Label (new Rect (10, 30, 500, 30), "Scene : " + scene);
//			GUI.Label (new Rect (10, 50, 500, 30), "Position : " + position.ToString());
//			GUI.Label (new Rect (10, 70, 500, 30), "Experience : " + experienceVal);
//			GUI.Label (new Rect (10, 90, 500, 30), "Level : " + currentLevel);
//		}

		public void Save () {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Create (Application.persistentDataPath + "/PlayerData.dat");

			PlayerData data = new PlayerData ();

			bf.Serialize (file, data);
			file.Close ();
		}

		public void Load () {
			if (File.Exists (Application.persistentDataPath + "/PlayerData.dat")) {
				BinaryFormatter bf = new BinaryFormatter();
				FileStream file = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
				PlayerData data = (PlayerData)bf.Deserialize(file);
				file.Close();

				health = data.health;
				scene = data.scene;
				position.x = data.x;
				position.y = data.y;
				position.z = data.z;
				experienceVal = data.experienceVal;
				currentLevel = data.currentLevel;

				load = true;
			}
		}
	}

	[Serializable]
	class PlayerData {
		public int health;
		public string scene;
		public float x;
		public float y;
		public float z;
		public int experienceVal;
		public int currentLevel;

		public PlayerData () {
			health = PlayerInfo.playerinfo.health;
			scene = PlayerInfo.playerinfo.scene;
			x = PlayerInfo.playerinfo.position.x;
			y = PlayerInfo.playerinfo.position.y;
			z = PlayerInfo.playerinfo.position.z;
			experienceVal = PlayerInfo.playerinfo.experienceVal;
			currentLevel = PlayerInfo.playerinfo.currentLevel;
		}
	}
}