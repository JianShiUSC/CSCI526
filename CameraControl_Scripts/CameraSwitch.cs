using UnityEngine;
using System.Collections;

namespace ThirdPersonRPG.Player {
	public class CameraSwitch : MonoBehaviour {
		public GameObject mentionText;
		bool isSecondary;
		public float waitingSecond = 20f;
		public GameObject mainCamera;
		public GameObject secondaryCamera;
//		public GameObject BossCamera;
		public GameObject StoryTeller;
		
		
		//GameObject player;
		public ThirdPersonUserControl user;
		public GameObject joystick;
		public GameObject mtjoystick;
		
		public GameObject magic_attack;
		int count = 1;
		//public GameObject boss;
		public GameObject[] spawnPoints;
		public EnemyManager enemymanager;
		public GameObject flashRed;
		public GameObject settingButton;

		public GameObject NPC;
		public GameObject miniMap;

//		public GameObject taskButton;
		
		
		// Use this for initialization
		void Start () 
		{
			//spawnPoints = GameObject.FindGameObjectsWithTag ("SpawningPoint");
			//enemymanager = GameObject.FindGameObjectWithTag ("EnemyManager");
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			user = player.GetComponent<ThirdPersonUserControl> ();
			
			isSecondary = true;
			secondaryCamera.SetActive(true);
			mainCamera.SetActive(false);
//			BossCamera.SetActive (false);

			NPC.SetActive (false);
			miniMap.SetActive (false);

			user.enabled = false;
			joystick.SetActive (false);
			mtjoystick.SetActive (false);
			
			magic_attack.SetActive (false);

			settingButton.SetActive (false);
			flashRed.SetActive (false);
//			taskButton.SetActive (false);
			enemymanager.gameObject.SetActive (false);
			foreach(GameObject spawnPoint in spawnPoints) {
				spawnPoint.SetActive (false);
			}
			Invoke ("switchCamera", waitingSecond);
		}
		
		void Update()
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			if (enemies.Length == 0 && count == 1 && enemymanager.inGame == true)
			{
				count = count -1;
//				BossCamera.SetActive (true);
				secondaryCamera.SetActive(false);
				mainCamera.SetActive(false);
				user.enabled = false;
				joystick.SetActive (false);
				mtjoystick.SetActive (false);
				magic_attack.SetActive (false);
				settingButton.SetActive (false);
				flashRed.SetActive(false);
//				taskButton.SetActive (false);
				Invoke ("switchCamera", 10f);
			}
		}
		
		void switchCamera()
		{
			StoryTeller.SetActive (false);
			mentionText.SetActive (false);
//			BossCamera.SetActive (false);
			secondaryCamera.SetActive (false);
			foreach(GameObject spawnPoint in spawnPoints) {
				spawnPoint.SetActive (true);
			}

			NPC.SetActive (true);
			miniMap.SetActive (true);
//			Time.timeScale = 0;

			enemymanager.gameObject.SetActive (true);
			mainCamera.SetActive (true);
			joystick.SetActive (true);
			mtjoystick.SetActive (true);
			magic_attack.SetActive (true);
			settingButton.SetActive (true);
//			taskButton.SetActive (true);
			user.enabled = true;
			flashRed.SetActive (true);
		}
	}
}