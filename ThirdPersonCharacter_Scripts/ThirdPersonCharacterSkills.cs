using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace ThirdPersonRPG.Player
{
	public class ThirdPersonCharacterSkills : MonoBehaviour 
	{
		public bool cont = true;

		public float AreaAttackRadius = 10f;
		public int AreaAttackDamageValue = 100;

		public float PhysicalAttackRadius = 3f;
		public float PhysicalAttackAngle = 90f;

		public float ExpValue = 15f;
		public float NormalPushValue = 5f;
		public float HardPushValue = 25f;

		public int AngryValue = 400;

		public int FrozenTime = 3;
		public Image MagicAttack1;
		public Image MagicAttack2;
		public Image MagicAttack3;

		public Image AreaAttack;

		Animator anim;

		bool MagicAttack1Touchable = true;
		bool MagicAttack2Touchable = true;
		bool MagicAttack3Touchable = true;

		bool Combo1 = true;
		bool Combo2 = true;
		bool Combo3 = true;
		bool Combo4 = true;
		bool Combo5 = true;


		bool AreaAttackTouchable = true;

		struct Constants 
		{
			public static string BlockButton = "Block";
			public static string ComboButton = "Combo";

			public static string AnimatorControllerBoolBlock = "Block";
			public static string AnimatorControllerBoolInBattle = "InBattle";
			public static string AnimatorControllerBoolCombo = "Combo";

			public static string AnimatorControllerTriggerAreaAttack = "AreaAttack";
		}

		void Awake () 
		{
			anim = gameObject.GetComponent<Animator> ();
		}
		
		void Update () 
		{
			if (CrossPlatformInputManager.GetButtonDown(Constants.BlockButton)) 
			{
				anim.SetBool (Constants.AnimatorControllerBoolInBattle , true);
				anim.SetBool (Constants.AnimatorControllerBoolBlock, true);
			}

			if (CrossPlatformInputManager.GetButtonUp (Constants.BlockButton)) 
			{
				anim.SetBool (Constants.AnimatorControllerBoolBlock, false);
			}

			if (CrossPlatformInputManager.GetButtonDown (Constants.ComboButton)) 
			{
				anim.SetBool (Constants.AnimatorControllerBoolCombo, true);
			}

			if (anim.IsInTransition (0) && CrossPlatformInputManager.GetButton("Combo") == false) {
			    anim.SetBool("Combo", false);
			}

			// Physical Attack
			if (anim.IsInTransition (0) && anim.GetNextAnimatorStateInfo (0).IsName ("Combo1") && Combo1) {
				StartCoroutine(PhysicalAttackSkill(anim.GetNextAnimatorClipInfo(0).Length*0.6f, 1));
				Combo1 = false;
				Combo2 = true;
			}

			if (anim.IsInTransition (0) && anim.GetNextAnimatorStateInfo (0).IsName ("Combo2") && Combo2) {
				StartCoroutine(PhysicalAttackSkill(anim.GetNextAnimatorClipInfo(0).Length*0.6f, 2));
				Combo2 = false;
				Combo3 = true;
			}

			if (anim.IsInTransition (0) && anim.GetNextAnimatorStateInfo (0).IsName ("Combo3") && Combo3) {
				StartCoroutine(PhysicalAttackSkill(anim.GetNextAnimatorClipInfo(0).Length, 3));
				StartCoroutine(PhysicalAttackSkill(anim.GetNextAnimatorClipInfo(0).Length*1.5f, 3));

				Combo3 = false;
				Combo4 = true;
			}

			if (anim.IsInTransition (0) && anim.GetNextAnimatorStateInfo (0).IsName ("Combo4") && Combo4) {
				StartCoroutine(PhysicalAttackSkill(anim.GetNextAnimatorClipInfo(0).Length*0.8f, 4));
				Combo4 = false;
				Combo5 = true;
			}

			if (anim.IsInTransition (0) && anim.GetNextAnimatorStateInfo (0).IsName ("Combo5") && Combo5) {
				StartCoroutine(PhysicalAttackSkill(anim.GetNextAnimatorClipInfo(0).Length*0.4f, 5));
				Combo5 = false;
				Combo1 = true;
			}

			// AreaAttackTouchable according to magic value
			if (gameObject.GetComponent<PlayerAngryValue>().currentAngryValue < AngryValue) {
				AreaAttackTouchable = false;
				AreaAttack.color = new Color32(255, 255, 255, 100);
			} else {
				AreaAttackTouchable = true;
				AreaAttack.color = new Color32(255, 255, 255, 255);
			}

			if (anim.IsInTransition (0)) {
				anim.ResetTrigger ("MagicAttack1");
				anim.ResetTrigger ("MagicAttack2");
				anim.ResetTrigger ("MagicAttack3");
				anim.ResetTrigger ("AreaAttack");
				anim.ResetTrigger ("Hit");
				if (anim.GetNextAnimatorStateInfo(0).IsName("InBattle")) {
					Combo1 = true;
				}
			}
		}

		private IEnumerator PhysicalAttackSkill (float waitPeriod, int damageAmount) {
			yield return new WaitForSeconds (waitPeriod);
			float attackAngle = PhysicalAttackAngle;
			if (damageAmount == 4) {
				attackAngle = 400f;
			}
			float attackRadius = PhysicalAttackRadius;
			if (damageAmount == 5) {
				attackRadius = AreaAttackRadius;
			}

			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			GameObject[] enemiesAndBoss = new GameObject[enemies.Length+3];
			enemies.CopyTo(enemiesAndBoss, 0);
			enemiesAndBoss[enemies.Length] = GameObject.FindGameObjectWithTag("Boss1");
			enemiesAndBoss[enemies.Length+1] = GameObject.FindGameObjectWithTag("Boss2");
			enemiesAndBoss[enemies.Length+2] = GameObject.FindGameObjectWithTag("Boss3");

//			foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
			foreach(GameObject enemy in enemiesAndBoss) {
				if (enemy != null && Vector3.Distance(transform.position, enemy.transform.position) <= attackRadius && Mathf.Abs( Vector3.Angle(enemy.transform.position - transform.position, transform.forward)) <= attackAngle) {
					Vector3 force = (enemy.transform.position - transform.position).normalized;
					if (damageAmount == 4) {
						enemy.GetComponent<Rigidbody>().AddForce(force * ExpValue, ForceMode.Impulse);
					} else if (damageAmount == 3 && waitPeriod == anim.GetCurrentAnimatorClipInfo(0).Length*1.5f) {
						enemy.GetComponent<Rigidbody>().AddForce(force * HardPushValue, ForceMode.Impulse);
					} else {
						enemy.GetComponent<Rigidbody>().AddForce(force * NormalPushValue, ForceMode.Impulse);
					}
					
					if (damageAmount >= 4) {
						enemy.GetComponent<EnemyHealth>().TakeDamage(damageAmount * damageAmount);
					} else  {
						enemy.GetComponent<EnemyHealth>().TakeDamage(damageAmount);
					}
				}
			}
		}


		public void AreaAttackSkill () {
			if (AreaAttackTouchable) {
				gameObject.GetComponent<PlayerAngryValue>().currentAngryValue -= AngryValue;
				anim.SetBool (Constants.AnimatorControllerBoolInBattle , true);
				anim.SetTrigger(Constants.AnimatorControllerTriggerAreaAttack);
				GameObject.FindGameObjectWithTag("EffectManager").GetComponent<EffectManager>().PlayEffect(EffectManager.EffectNames.AreaAttack, transform.position);

				GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
				GameObject[] enemiesAndBoss = new GameObject[enemies.Length+3];
				enemies.CopyTo(enemiesAndBoss, 0);
				enemiesAndBoss[enemies.Length] = GameObject.FindGameObjectWithTag("Boss1");
				enemiesAndBoss[enemies.Length+1] = GameObject.FindGameObjectWithTag("Boss2");
				enemiesAndBoss[enemies.Length+2] = GameObject.FindGameObjectWithTag("Boss3");

//				foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
				foreach(GameObject enemy in enemiesAndBoss) {
					if (enemy != null && Vector3.Distance(transform.position, enemy.transform.position) <= AreaAttackRadius) {
						Vector3 force = (enemy.transform.position - transform.position).normalized * ExpValue;

						enemy.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
						enemy.GetComponent<EnemyHealth>().TakeDamage(AreaAttackDamageValue);
					}
				}
			}
		}

		public void MagicAttack (string MagicAttackName) 
		{
			if (MagicAttackName == "MagicAttack1" && MagicAttack1Touchable || MagicAttackName == "MagicAttack2" && MagicAttack2Touchable || MagicAttackName == "MagicAttack3" && MagicAttack3Touchable ) {
				StartCoroutine (attackAndWait(MagicAttackName, Time.time));
			}
		}

		private IEnumerator attackAndWait (string MagicAttackName, float InitTime) {
			Image attackImage = MagicAttack1;

			if (MagicAttackName == "MagicAttack1") {
				attackImage = MagicAttack1;
				MagicAttack1Touchable = false;
			}
			if (MagicAttackName == "MagicAttack2") {
				attackImage = MagicAttack2;
				MagicAttack2Touchable = false;
			}
			if (MagicAttackName == "MagicAttack3") {
				attackImage = MagicAttack3;
				MagicAttack3Touchable = false;
			}

			anim.SetBool (Constants.AnimatorControllerBoolInBattle , true);
			anim.SetTrigger (MagicAttackName);
			GameObject.FindGameObjectWithTag("EffectManager").GetComponent<EffectManager>().PlayEffect(MagicAttackName, transform.position);

			attackImage.color = new Color32 (255, 255, 255, 100);
			Text text = attackImage.GetComponentInChildren<Text> ();

			while (Time.time - InitTime <= FrozenTime && cont) {
				float curr = Time.time - InitTime;
//				if (0f <= curr &&  curr <= 1f) {
//					text.text = "3";
//					text.color = new Color32 (50, 50, 100,  byte.Parse((Mathf.Ceil(255*(1f-curr)).ToString())));
//				}
//				if (1f < curr &&  curr <= 2f) {
//					text.text = "2";
//					text.color = new Color32 (50, 50, 100,  byte.Parse((Mathf.Ceil(255*(2f-curr)).ToString())));
//				}
				if (FrozenTime-1 <= Mathf.FloorToInt(curr) &&  Mathf.FloorToInt(curr) <= FrozenTime) {
					text.text = "1";
					text.color = new Color32 (150, 50, 50,  byte.Parse((Mathf.Ceil(255*(FrozenTime-curr)).ToString())));
				} else {
					text.text = (FrozenTime-Mathf.FloorToInt(curr)).ToString();
					text.color = new Color32 (50, 50, 100, 255);
				}
				yield return new WaitForSeconds (0.01f);
			}

			text.text = "";
			attackImage.color = new Color32 (255, 255, 255, 255);

			if (MagicAttackName == "MagicAttack1") {
				MagicAttack1Touchable = true;
			}
			if (MagicAttackName == "MagicAttack2") {
				MagicAttack2Touchable = true;
			}
			if (MagicAttackName == "MagicAttack3") {
				MagicAttack3Touchable = true;
			}
		}
	}
}
