using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ThirdPersonRPG.Player;

public class EnemyHealth : MonoBehaviour 
{
	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
//	public int scoreValue = 10;
	public AudioClip deathClip;
	//LXQ
	public Transform Coins;
	public Transform EnergyBottle;
	public Transform HealthBottle;
//	public Transform Weapons;

	public Transform DoubleAxe;
	public Transform ElvenSword;
	public Transform FantasySword;
	public Transform DarkSword;
	public Transform Hammer;
	public Transform Mace;
	public Transform SkullAxe;

	public Transform Armor;
	public Transform Hands;
	public Transform Boots;
	public Transform Helmets;
	public Transform Hats;

	public bool MagicAttack1 = false;
	public bool MagicAttack2 = false;
	public bool MagicAttack3 = false;

	private float currentPeriod1 = 0f;
	private float currentPeriod2 = 0f;
	private float currentPeriod3 = 0f;
	
	Animator anim;
	AudioSource enemyAudio;
	ParticleSystem hitParticles;
	CapsuleCollider capsuleCollider;
	bool isSinking;

	LevelAndExp levelExp;

	public bool isDead;

	void Awake()
	{
		anim = GetComponent <Animator> ();
		enemyAudio = GetComponent <AudioSource> ();
		hitParticles = GetComponentInChildren <ParticleSystem> ();
		capsuleCollider = GetComponent <CapsuleCollider> ();
		levelExp = GameObject.FindGameObjectWithTag ("LevelSystem").GetComponent<LevelAndExp> ();

		currentHealth = startingHealth;
	}

	void Update()
	{
		if (isSinking)
		{
//			Debug.Log("sinking");
			transform.Translate(-Vector3.up * sinkSpeed * 0.05f * Time.deltaTime);
		}
	}

	void FixedUpdate () {
		if (MagicAttack1) {
			currentPeriod1 += Time.fixedDeltaTime;
			if (currentPeriod1 >= MagicAttack.timePeriod) {
				TakeDamage(MagicAttack.MagicAttack1DamagePerPeriod);
				currentPeriod1 = 0;
			}
		}

		if (MagicAttack2) {
			currentPeriod2 += Time.fixedDeltaTime;
			if (currentPeriod2 >= MagicAttack.timePeriod) {
				TakeDamage(MagicAttack.MagicAttack2DamagePerPeriod);
				currentPeriod2 = 0;
			}
		}

		if (MagicAttack3) {
			currentPeriod3 += Time.fixedDeltaTime;
			if (currentPeriod3 >= MagicAttack.timePeriod) {
				TakeDamage(MagicAttack.MagicAttack3DamagePerPeriod);
				currentPeriod3 = 0;
			}
		}
	}

	public void TakeDamage(int amount)
	{
		if (isDead)
			return;
		if (gameObject.tag == "Enemy") {
			enemyAudio.Play ();
			anim.SetTrigger ("Damage");
		}

		currentHealth -= amount;
		DamageEnemyWord.ShowMessage ("-" + amount.ToString(), transform.position);
//		hitParticles.transform.position = hitPoint;
//		hitParticles.Play ();

		if (currentHealth <= 0) 
		{
			Death ();
		}
	}

	void Death()
	{
		isDead = true;

		capsuleCollider.isTrigger = true;

		anim.SetTrigger("Dead");

		levelExp.experienceVal += 100;

		//LXQ
		DropItems ();

		enemyAudio.clip = deathClip;
		enemyAudio.Play ();

		if (gameObject.tag == "Boss1") {
			// NO EFFECT
		}

		if (gameObject.tag == "Boss2") {
			GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonCharacter>().m_AnimSpeed = 1f;
		}

		if (gameObject.tag == "Boss3") {
			Camera.main.GetComponent<ThirdPersonMainCameraControl> ().enabled = true;
			GameObject.FindGameObjectWithTag ("Joystick").GetComponent<Canvas> ().enabled = true;
			GameObject.FindGameObjectWithTag ("MTJoystick").GetComponent<Canvas> ().enabled = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<ThirdPersonCharacter> ().enabled = true;

			GameObject.FindGameObjectWithTag ("BlindCanvas").GetComponentInChildren<Image> ().color = new Color32(125, 0, 0, 0);
		}

		Invoke ("StartSinking", 5f);
	}

	//lxq
	public void DropItems()
	{
//		int num = (int)Mathf.Floor(Random.Range(0, 10));
//		if (num >= 6) 
//		{
//			return;
//		}
//		Transform[] items = new Transform[6];
//		items [0] = items [1] = Coins;
//		items [2] = EnergyBottle;
//		items [3] = items [4] = items [5] = HealthBottle;

		int num1 = (int)Mathf.Floor (Random.Range (0,8));
		if (num1 >= 8) 
		{
			return;
		}

		if (num1 == 0) {	//weapon
			int num2 = (int)Mathf.Floor (Random.Range (0,6));
			Transform[] items = new Transform[7];
			items[0] = DoubleAxe;
			items[1] = ElvenSword;
			items[2] = FantasySword;
			items[3] = DarkSword;
			items[4] = Hammer;
			items[5] = Mace;
			items[6] = SkullAxe;
			Instantiate (items[num2], new Vector3 (this.transform.position.x + 0.0f, 1f, this.transform.position.z), items[num2].rotation);
		}

		if (num1 == 1) {	//health
			Transform[] items = new Transform[1];
			items[0] = HealthBottle;
			Instantiate (items[0], new Vector3 (this.transform.position.x + 0.0f, 0.23f, this.transform.position.z), items[0].rotation);
		}

		if (num1 == 2) {	//magic
			Transform[] items = new Transform[1];
			items[0] = EnergyBottle;
			Instantiate (items[0], new Vector3 (this.transform.position.x + 0.0f, 0.23f, this.transform.position.z), items[0].rotation);
		}

		if (num1 == 3) {	//coin
			Transform[] items = new Transform[1];
			items[0] = Coins;
			Instantiate (items[0], new Vector3 (this.transform.position.x + 0.0f, 0f, this.transform.position.z), items[0].rotation);
		}
		if (num1 == 4) {	//armor
			Transform[] items = new Transform[1];
			items[0] = Armor;
			Instantiate (items[0], new Vector3 (this.transform.position.x + 0.0f, 0f, this.transform.position.z), items[0].rotation);
		}
		if (num1 == 5) {	//hands
			Transform[] items = new Transform[1];
			items[0] = Hands;
			Instantiate (items[0], new Vector3 (this.transform.position.x + 0.0f, 0f, this.transform.position.z), items[0].rotation);
		}
		if (num1 == 6) {	//boots
			Transform[] items = new Transform[1];
			items[0] = Boots;
			Instantiate (items[0], new Vector3 (this.transform.position.x + 0.0f, 0f, this.transform.position.z), items[0].rotation);
		}
		if (num1 == 7) {	//hats
			int num2 = (int)Mathf.Floor (Random.Range (0,1));
			Transform[] items = new Transform[2];
			items[0] = Helmets;
			items[1] = Hats;
			Instantiate (items[num2], new Vector3 (this.transform.position.x + 0.0f, 1f, this.transform.position.z), items[num2].rotation);
		}
	}


	public void StartSinking ()
	{
		///////////add delay
		GetComponent <NavMeshAgent> ().enabled = false;

		isSinking = true;
//		ScoreManager.score += scoreValue;

		if (gameObject.tag == "Boss3") {
			Camera.main.gameObject.SetActive(false);

			GameObject.FindGameObjectWithTag("MiniMapCanvas").SetActive(false);

			GameObject.FindGameObjectWithTag ("Joystick").GetComponent<Canvas> ().enabled = false;
			GameObject.FindGameObjectWithTag ("MTJoystick").GetComponent<Canvas> ().enabled = false;
			GameObject.FindGameObjectWithTag ("MagicAttackCanvas").GetComponent<Canvas> ().enabled = false;
			
			GameObject.FindGameObjectWithTag ("SettingCanvas").GetComponent<Canvas> ().enabled = false;
			GameObject.FindGameObjectWithTag ("FlashRedCanvas").GetComponent<Canvas> ().enabled = false;

			foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
				Destroy(enemy);
			}

			GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<BossManager>().FinishStory();
		}

		Destroy (gameObject, 10f);
	}
}
