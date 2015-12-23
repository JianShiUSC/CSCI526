using UnityEngine;
using System.Collections;

public class EffectManager : MonoBehaviour {

	public GameObject LevelUpEffect;
	public GameObject AreaAttackEffect;

	public GameObject MagicAttack1Effect;
	public GameObject MagicAttack2Effect;
	public GameObject MagicAttack3Effect;

	public GameObject Boss2FireStepPrint;

	public GameObject Boss3Attack1Effect;
	public GameObject Boss3Attack2Effect;
	
	public struct EffectNames {
		public static string LevelUp = "LevelUp";
		public static string AreaAttack = "AreaAttack";

		public static string MagicAttack1 = "MagicAttack1";
		public static string MagicAttack2 = "MagicAttack2";
		public static string MagicAttack3 = "MagicAttack3";

		public static string Boss2FireStepPrint = "Boss2FireStepPrint";

		public static string Boss3Attack1 = "Boss3Attack1";
		public static string Boss3Attack2 = "Boss3Attack2";
	}

	public struct EffectTimePeriod {
		public static float AreaAttackTimePeriod = 3f;
		public static float AreaAttackFadePeriod = 3f;
		public static float LevelUpTimePeriod = 3f;
		public static float LevelUpFadePeriod = 3f;
		public static float MagicAttack1TimePeriod = 5f;
		public static float MagicAttack1FadePeriod = 8f;
		public static float MagicAttack2TimePeriod = 5f;
		public static float MagicAttack2FadePeriod = 6f;
		public static float MagicAttack3TimePeriod = 5f;
		public static float MagicAttack3FadePeriod = 8f;

		public static float Boss2FireStepPrintTimePeriod = 10f;
		public static float Boss2FireStepPrintFadePeriod = 8f;

		public static float Boss3Attack1TimePeriod = 5f;
		public static float Boss3Attack1FadePeriod = 6f;
		public static float Boss3Attack2TimePeriod = 5f;
		public static float Boss3Attack2FadePeriod = 8f;

	}

	public void PlayEffect(string effectName, Vector3 position) {
		if (effectName == EffectManager.EffectNames.LevelUp) {
			StartCoroutine(playEffect(LevelUpEffect, position, EffectManager.EffectTimePeriod.LevelUpTimePeriod, EffectManager.EffectTimePeriod.LevelUpFadePeriod));
			return;
		}

		if (effectName == EffectManager.EffectNames.AreaAttack) {
			StartCoroutine(playEffect(AreaAttackEffect, position, EffectManager.EffectTimePeriod.AreaAttackTimePeriod, EffectManager.EffectTimePeriod.AreaAttackFadePeriod));
			return;
		}

		if (effectName == EffectManager.EffectNames.MagicAttack1) {
			StartCoroutine(playEffect(MagicAttack1Effect, position, EffectManager.EffectTimePeriod.MagicAttack1TimePeriod, EffectManager.EffectTimePeriod.MagicAttack1FadePeriod));
			return;
		}

		if (effectName == EffectManager.EffectNames.MagicAttack2) {
			StartCoroutine(playEffect(MagicAttack2Effect, position, EffectManager.EffectTimePeriod.MagicAttack2TimePeriod, EffectManager.EffectTimePeriod.MagicAttack2FadePeriod));
			return;
		}

		if (effectName == EffectManager.EffectNames.MagicAttack3) {
			StartCoroutine(playEffect(MagicAttack3Effect, position, EffectManager.EffectTimePeriod.MagicAttack3TimePeriod, EffectManager.EffectTimePeriod.MagicAttack3FadePeriod));
			return;
		}

		if (effectName == EffectManager.EffectNames.Boss2FireStepPrint) {
			StartCoroutine(playEffect(Boss2FireStepPrint, position, EffectManager.EffectTimePeriod.Boss2FireStepPrintTimePeriod, EffectManager.EffectTimePeriod.Boss2FireStepPrintFadePeriod));
			return;
		}

		if (effectName == EffectManager.EffectNames.Boss3Attack1) {
			StartCoroutine(playEffect(Boss3Attack1Effect, position, EffectManager.EffectTimePeriod.Boss3Attack1TimePeriod, EffectManager.EffectTimePeriod.Boss3Attack1FadePeriod));
			return;
		}

		if (effectName == EffectManager.EffectNames.Boss3Attack2) {
			StartCoroutine(playEffect(Boss3Attack2Effect, position, EffectManager.EffectTimePeriod.Boss3Attack2TimePeriod, EffectManager.EffectTimePeriod.Boss3Attack2FadePeriod));
			return;
		}
	}

	private IEnumerator playEffect(GameObject originObject, Vector3 position, float timePeriod, float fadePeriod) {
		position.y = originObject.transform.position.y;
		GameObject effectObject = (GameObject)Instantiate(originObject, position, originObject.transform.rotation);

		ParticleSystem particleSystem = effectObject.GetComponent<ParticleSystem> ();

		particleSystem.Play (true);

		yield return new WaitForSeconds (timePeriod);

		particleSystem.enableEmission = false;
		foreach (ParticleSystem childParticleSystem in effectObject.GetComponentsInChildren<ParticleSystem>()) {
			childParticleSystem.enableEmission = false;
		}

		StartCoroutine (destoryObject(effectObject, fadePeriod));
	}

	private IEnumerator destoryObject(GameObject effectObject, float fadePeriod) {
		yield return new WaitForSeconds (fadePeriod);
		effectObject.GetComponent<ParticleSystem> ().Stop ();
		Destroy (effectObject);
	}
}
