using UnityEngine;

namespace ThirdPersonRPG.Player
{
	public class BossManager : MonoBehaviour 
	{
		public PlayerHealth playerHealth;
		public GameObject enemy;
		public float spawnTime = 3f;
		public Transform[] spawnPoints;
		public int numberOfEnemy;
		public int count = 0;
//		public EnemyHealth enemyHealth;
		public int current_alive_num = 0;
		bool isAppear = false;

		public GameObject EndCamera;
		public GameObject EndStory;

		void Start () 
		{
//			Debug.Log ("cur1" + current_alive_num);
//			InvokeRepeating ("Spawn", 0, spawnTime);
//			InvokeRepeating ("Spawn", 0, spawnTime);

		}

		public void FinishStory () {
			EndCamera.SetActive (true);
			EndStory.SetActive (true);
		}

		void Update()
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
			current_alive_num = enemies.Length;
			if (current_alive_num == 0) 
			{
				InvokeRepeating ("Spawn", 0, spawnTime);
				isAppear = true;
			}
		}

		
		void Spawn()
		{
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			if (count < numberOfEnemy) 
			{
				GameObject Boss = (GameObject)Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
				Boss.SetActive(true);
				count++;
			}
		}
	}
}