using UnityEngine;

namespace ThirdPersonRPG.Player
{
	public class EnemyManager : MonoBehaviour 
	{
		public PlayerHealth playerHealth;
		public GameObject enemy;
		public float spawnTime = 3f;
		public Transform[] spawnPoints;
		public int numberOfEnemy;
		public int count = 0;
		public bool inGame = false;

		void Start () 
		{
			InvokeRepeating ("Spawn", 0, spawnTime);
		}
		
		void Spawn()
		{
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			if (count < numberOfEnemy) 
			{
				GameObject newenemy = (GameObject)Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
				newenemy.SetActive(true);
				count++;
				inGame = true;
			}
		}
	}
}