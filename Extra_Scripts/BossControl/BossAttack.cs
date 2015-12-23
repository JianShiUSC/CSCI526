using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using ThirdPersonRPG.Player;

public class BossAttack : MonoBehaviour {
	// GENERAL
	private Animator anim;
	private PlayerHealth playerHealth;
	private float attackDistance = 3f;
	private int attackDamage = 10;
	private float timePeriod = 5f;

	// BOSS1
	private GameObject split1;
	private GameObject split2;

	// BOSS2
	private bool switchMode = true;
	private int stat = 0;
	private GameObject boss2Ice;
	private GameObject boss2Fire;
	private GameObject boss2Tree;
	private bool startFireStepPrint = false;
	private float currentPeriod = 0f;
	private float fireStepPeriod = 0.1f;

	// BOSS3
	private float shakeAmount = 0.2f;
	private bool shake = false;
	private Image blindImage = null;
	private bool blind = false;
	private bool recovery = true;
	private int a = 0;
	private int changeRate = 5;

	void Awake () {
		anim = gameObject.GetComponent<Animator> ();
		playerHealth = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ();

		boss2Ice = GameObject.FindGameObjectWithTag ("DemonIce");
		boss2Fire = GameObject.FindGameObjectWithTag ("DemonFire");
		boss2Tree = GameObject.FindGameObjectWithTag ("DemonTree");

		blindImage = GameObject.FindGameObjectWithTag ("BlindCanvas").GetComponentInChildren<Image> ();
//		blindImage.GetComponent<RectTransform> ().sizeDelta = new Vector2(Screen.width, Screen.height);
		blindImage.color = new Color32 (125, 0, 0, 0);
	}

	// Use this for initialization
	void Start () {
		if (gameObject.tag == "Boss1") {
			InvokeRepeating ("bossReleaseSkills", 0f, 2f);
			InvokeRepeating ("boss1SwitchPosition", 0f, 2f);
			InvokeRepeating ("boss1SplitSelf", 10f, 10f);
		}
		if (gameObject.tag == "Boss2") {
			InvokeRepeating ("bossReleaseSkills", 0f, 2f);
			InvokeRepeating ("boss2SwitchMode", 0f, 5f);
		}
		if (gameObject.tag == "Boss3") {
			InvokeRepeating ("boss3ReleaseSkills", 0f, 2f);
		}
	}

	void FixedUpdate () {
		if (startFireStepPrint) {
			currentPeriod += Time.fixedDeltaTime;
			if (currentPeriod >= fireStepPeriod) {
				GameObject.FindGameObjectWithTag("EffectManager").GetComponent<EffectManager>().PlayEffect(EffectManager.EffectNames.Boss2FireStepPrint, transform.position);
				currentPeriod = 0;
			}
		}

		if (gameObject.GetComponent<EnemyHealth>().isDead) {
			if (gameObject.tag == "Boss1" || gameObject.tag == "Boss2" || gameObject.tag == "Boss3") {
				CancelInvoke();
			}
		}
	}

	void Update () {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("SwitchMode") && switchMode) {
			Invoke("boss2SwitchModeEffect", 1f);
			switchMode = false;
		}

		if (shake) {
			Transform original = Camera.main.transform;
			Camera.main.transform.position += Random.insideUnitSphere * shakeAmount;
			Camera.main.transform.position = original.position;
		}
		if (blind && a < 255) {
			a += changeRate;
			if (a > 255) {
				a = 255;
			}
			blindImage.color = new Color32(125, 0, 0, byte.Parse(a.ToString()));
		}
		if (recovery && a > 0) {
			a -= changeRate;
			if (a < 0) {
				a = 0;
			}
			blindImage.color = new Color32(125, 0, 0, byte.Parse(a.ToString()));
		}
	}

	private void boss1SwitchPosition () {
		Vector3 randomOffset = Random.insideUnitSphere;
		randomOffset.y = 0f;
		gameObject.transform.position =  GameObject.FindGameObjectWithTag ("Player").transform .position+ randomOffset.normalized;
	}

	private void boss1SplitSelf() {
		Vector3 randomOffset = Random.insideUnitSphere;
		randomOffset.y = 0f;
		split1 = (GameObject)Instantiate(gameObject, GameObject.FindGameObjectWithTag ("Player").transform .position+ randomOffset.normalized, gameObject.transform.rotation);

		randomOffset = Random.insideUnitSphere;
		randomOffset.y = 0f;
		split2 = (GameObject)Instantiate(gameObject, GameObject.FindGameObjectWithTag ("Player").transform .position+ randomOffset.normalized, gameObject.transform.rotation);

		Invoke ("destroySplitBoss", 5f);
	}

	private void destroySplitBoss () {
		Destroy (split1);
		Destroy (split2);
	}

	private void bossReleaseSkills () {
		int skillNum = Random.Range (1, 8);
		switch (skillNum) {
		case 1:
		case 2:
			if (Vector3.Distance (playerHealth.gameObject.transform.position, gameObject.transform.position) < attackDistance) {
				playerHealth.TakeDamage (attackDamage);
				anim.SetTrigger ("PhysicalAttack1");
			}
			break;
		case 3:
		case 4:
			if (Vector3.Distance (playerHealth.gameObject.transform.position, gameObject.transform.position) < attackDistance) {
				playerHealth.TakeDamage (attackDamage);
				anim.SetTrigger ("PhysicalAttack2");
			}
			break;
		case 5:
		case 6:
			if (Vector3.Distance (playerHealth.gameObject.transform.position, gameObject.transform.position) < attackDistance) {
				playerHealth.TakeDamage (attackDamage);
				anim.SetTrigger ("PhysicalAttack3");
			}
			break;
		case 7:
		case 8:
			if (Vector3.Distance (playerHealth.gameObject.transform.position, gameObject.transform.position) < attackDistance) {
				playerHealth.TakeDamage (attackDamage);
				anim.SetTrigger ("ComboAttack");
			}
			break;
		}
	}

	private void boss2SwitchMode () {
		Debug.Log ("Switch");
		anim.SetTrigger ("SwitchMode");

		anim.ResetTrigger ("PhysicalAttack1");
		anim.ResetTrigger ("PhysicalAttack2");
		anim.ResetTrigger ("PhysicalAttack3");
		anim.ResetTrigger ("ComboAttack");

		switchMode = true;
	}

	private void boss2SwitchModeEffect() {
		stat = (stat + 1) % 3;
		Debug.Log ("SWITCH"+stat.ToString());
		switch (stat) {
		case 0: // ICE
			boss2Ice.SetActive(true);
			boss2Fire.SetActive(false);
			boss2Tree.SetActive(false);

			GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonCharacter>().m_AnimSpeed = 0.3f;
			anim.speed = 3f;
			attackDamage = 10;
			startFireStepPrint = false;
			break;
		case 1: // FIRE
			boss2Ice.SetActive(false);
			boss2Fire.SetActive(true);
			boss2Tree.SetActive(false);

			GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonCharacter>().m_AnimSpeed = 1f;
			anim.speed = 1f;
			attackDamage = 20;
			startFireStepPrint = true;
			break;
		case 2: // TREE
			boss2Ice.SetActive(false);
			boss2Fire.SetActive(false);
			boss2Tree.SetActive(true);

			GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonCharacter>().m_AnimSpeed = 1f;
			anim.speed = 1f;
			attackDamage = 10;
			startFireStepPrint = false;
			break;
		}
	}

	private void boss3ReleaseSkills () {
		int skillNum = Random.Range (1, 11);
		switch (skillNum) {
		case 1:
		case 2:
			if (Vector3.Distance (playerHealth.gameObject.transform.position, gameObject.transform.position) < attackDistance) {
				playerHealth.TakeDamage (attackDamage);
				anim.SetTrigger ("PhysicalAttack1");
			}
			break;
		case 3:
		case 4:
			if (Vector3.Distance (playerHealth.gameObject.transform.position, gameObject.transform.position) < attackDistance) {
				playerHealth.TakeDamage (attackDamage);
				anim.SetTrigger ("PhysicalAttack2");
			}
			break;
		case 5:
		case 6:
			if (Vector3.Distance (playerHealth.gameObject.transform.position, gameObject.transform.position) < attackDistance) {
				playerHealth.TakeDamage (attackDamage);
				anim.SetTrigger ("PhysicalAttack3");
			}
			break;
		case 7:
		case 8:
			if (Vector3.Distance (playerHealth.gameObject.transform.position, gameObject.transform.position) < attackDistance) {
				playerHealth.TakeDamage (attackDamage);
				anim.SetTrigger ("ComboAttack");
			}
			break;
		case 9:
			anim.SetTrigger ("MagicAttack1");
			GameObject.FindGameObjectWithTag("EffectManager").GetComponent<EffectManager> ().PlayEffect (EffectManager.EffectNames.Boss3Attack1, transform.position);
			StartCoroutine(shakeCamera());
			break;
		case 10:
			anim.SetTrigger ("MagicAttack2");
			GameObject.FindGameObjectWithTag("EffectManager").GetComponent<EffectManager> ().PlayEffect (EffectManager.EffectNames.Boss3Attack2, transform.position);
			StartCoroutine(blindEyes());
			break;
		}
	}

	private IEnumerator blindEyes () {
		blind = true;
		recovery = false;

		yield return new WaitForSeconds (timePeriod);

		blind = false;
		recovery = true;
	}

	private IEnumerator shakeCamera () {
		GameObject.FindGameObjectWithTag ("Joystick").GetComponent<Canvas> ().enabled = false;
		GameObject.FindGameObjectWithTag ("MTJoystick").GetComponent<Canvas> ().enabled = false;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<ThirdPersonCharacter> ().enabled = false;

		Camera.main.GetComponent<ThirdPersonMainCameraControl> ().enabled = false;

		shake = true;

		yield return new WaitForSeconds (timePeriod);

		shake = false;

		Camera.main.GetComponent<ThirdPersonMainCameraControl> ().enabled = true;
		GameObject.FindGameObjectWithTag ("Joystick").GetComponent<Canvas> ().enabled = true;
		GameObject.FindGameObjectWithTag ("MTJoystick").GetComponent<Canvas> ().enabled = true;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<ThirdPersonCharacter> ().enabled = true;

	}
}