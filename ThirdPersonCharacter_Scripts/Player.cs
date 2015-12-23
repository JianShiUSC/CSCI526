using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace ThirdPersonRPG.Player
{

	public class Player : MonoBehaviour {
		private int maxHealth = 500;
		public GameObject healthBarObj;
		private Image healthBar; 
		private PlayerHealth ph;
		public Color MaxHealthColor = Color.green;
		public Color MinHealthColor = Color.red;
		public GameObject player;
		public int counter = 500;

		// Use this for initialization
		void Start () {
			maxHealth = 500;
//			healthBar = transform.FindChild ("PlayerCanvas").FindChild ("HealthBG").FindChild ("Health").GetComponent<Image> ();
			healthBar = healthBarObj.GetComponent<Image> ();
			ph = player.GetComponent<PlayerHealth> ();
			 
		}
		
		// Update is called once per frame
		void Update () {
			counter = ph.currentHealth;
			Hit (counter);
		}
		public void Hit(int currentHealth)
		{
			//health -= damage;
			healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
			healthBar.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)currentHealth / maxHealth);
		}
	}
}