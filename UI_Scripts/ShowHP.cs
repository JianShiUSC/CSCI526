using UnityEngine.UI;
using UnityEngine;
using System.Collections;

namespace ThirdPersonRPG.Player
{
	public class ShowHP : MonoBehaviour 
	{
		PlayerHealth playerHealth;
		Energy coinEnergy;
		ThirdPersonCharacter v_multiplyer;

		GameObject levelAndExperience;


		public GameObject Life_val;
		public GameObject BurningGroundDamage;
		public GameObject HolyShineDamage;
		public GameObject CycloneDamage;
		public GameObject coin_num;
		public GameObject velocity_val;
		public GameObject fire_R;
		public GameObject cold_R;
		public GameObject light_R;
		
		public GameObject level;
		public GameObject cur_experience;
		public GameObject nextLevel;
		
		// Use this for initialization
		void Awake () 
		{
			playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();
			coinEnergy = GameObject.FindGameObjectWithTag ("Player").GetComponent<Energy> ();
			v_multiplyer = GameObject.FindGameObjectWithTag ("Player").GetComponent<ThirdPersonCharacter> ();
			levelAndExperience = GameObject.FindGameObjectWithTag("LevelSystem");
		}
		
		// Update is called once per frame
		void Update () 
		{
			Life_val.GetComponent<Text>().text = playerHealth.currentHealth.ToString();
			BurningGroundDamage.GetComponent<Text> ().text = MagicAttack.MagicAttack3DamagePerPeriod.ToString () + "/" + MagicAttack.timePeriod.ToString () + "s";
			HolyShineDamage.GetComponent<Text> ().text = MagicAttack.MagicAttack2DamagePerPeriod.ToString () + "/" + MagicAttack.timePeriod.ToString () + "s";
			CycloneDamage.GetComponent<Text> ().text = MagicAttack.MagicAttack1DamagePerPeriod.ToString () + "/" + MagicAttack.timePeriod.ToString () + "s";
			coin_num.GetComponent<Text> ().text = coinEnergy.currentcoins.ToString ();
			velocity_val.GetComponent<Text> ().text = v_multiplyer.m_Multiplyer.ToString ();
			
			//Debug.Log (alien.GetComponent<EnemyAttack> ().attackDamage);
			fire_R.GetComponent<Text> ().text = (playerHealth.resistency_zombie*10).ToString();
			cold_R.GetComponent<Text> ().text = (playerHealth.resistency_fantasy*10).ToString();
			light_R.GetComponent<Text> ().text = (playerHealth.resistency_alien*10).ToString();
			level.GetComponent<Text> ().text = levelAndExperience.GetComponent<LevelAndExp>().currentLevel.ToString();
			cur_experience.GetComponent<Text> ().text = levelAndExperience.GetComponent<LevelAndExp>().experienceVal.ToString();
			nextLevel.GetComponent<Text> ().text = levelAndExperience.GetComponent<LevelAndExp>().nextLevel.ToString();
		}
	}
}