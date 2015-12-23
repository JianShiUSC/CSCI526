using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace ThirdPersonRPG.Player
{
	public class PlayerHealth : MonoBehaviour
	{
		public int startingHealth = 100;                            // The amount of health the player starts the game with.
		public int currentHealth = 100;                                   // The current health the player has.
		//public Slider healthSlider;                                 // Reference to the UI's health bar.
		public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
		public AudioClip[] deathClip;                                 // The audio clip to play when the player dies.
		public AudioClip[] hitClip;
		public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
		public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
		public bool isDead;                                                // Whether the player is dead.
		public GameObject deathCanvas;
		
		public int resistency_zombie = 0;
		public int resistency_alien = 0;
		public int resistency_fantasy = 0;
		
		public bool FirePrint = false;
		private float currentPeriod = 0f;

		//lxq
		public GameObject gameoverScreen;
		public Image gameoverImg;
		bool Gover = false;
		Color fullAlpha = new Color (0f, 0f, 0f, 1f);
		Color zeroAlpha = new Color (0f, 0f, 0f, 0f);
		float gameoverSpeed = 0.3f;
		
		private Inventory inventory;
		private CharacterSlot[] characterSlots;

		Animator anim;                                              // Reference to the Animator component.
		AudioSource playerAudio;                                    // Reference to the AudioSource component.
		//PlayerMovement playerMovement;                              // Reference to the player's movement.
		bool damaged;                                               // True when the player gets damaged.
		
		
		void Awake ()
		{
			// Setting up the references.
			anim = GetComponent <Animator> ();
			playerAudio = GetComponent <AudioSource> ();
			//playerMovement = GetComponent <PlayerMovement> ();
			
			// Set the initial health of the player.
			currentHealth = startingHealth;
			
			hitClip =  new AudioClip[]{
				(AudioClip)Resources.Load("Hit & Damage 1"),
				(AudioClip)Resources.Load("Hit & Damage 2"), 
				(AudioClip)Resources.Load("Hit & Damage 3"),
				(AudioClip)Resources.Load("Hit & Damage 4"),
				(AudioClip)Resources.Load("Hit & Damage 5"), 
				(AudioClip)Resources.Load("Hit & Damage 6"),
				(AudioClip)Resources.Load("Hit & Damage 7"),
				(AudioClip)Resources.Load("Hit & Damage 8")};
			
			deathClip = new AudioClip[]{
				(AudioClip)Resources.Load("Hit & Damage 9"),
				(AudioClip)Resources.Load("Hit & Damage 10"),
				(AudioClip)Resources.Load("Hit & Damage 11")};

			inventory = GameObject.FindGameObjectWithTag ("Inventory").GetComponent<Inventory> ();
			characterSlots = GameObject.FindGameObjectWithTag ("CharacterSystem").GetComponentsInChildren<CharacterSlot> ();
		}
		
		void Start () {
			//Debug.Log (PlayerInfo.playerinfo.load);
			Debug.Log (PlayerInfo.playerinfo.health);
			currentHealth = PlayerInfo.playerinfo.health;

			if (PlayerInfo.playerinfo.load) {
				gameObject.transform.position = PlayerInfo.playerinfo.position;
				PlayerInfo.playerinfo.load = false;
			}
		}
		
		void FixedUpdate () {
			if (FirePrint) {
				currentPeriod += Time.fixedDeltaTime;
				if (currentPeriod >= MagicAttack.timePeriod) {
					TakeDamage(MagicAttack.Boss2FireStepPrintDamagePerPeriod);
					currentPeriod = 0;
				}
			}
		}

		void Update ()
		{
			if(damaged)
			{
				damageImage.color = flashColour;
			}
			else
			{
				damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
			}
			damaged = false;

			if(currentHealth > 0 && isDead)
			{
				isDead = false;
				anim.SetTrigger ("Restart");
			}

			//lxq
			if (Gover) 
			{
				gameoverImg.color= Color.Lerp(gameoverImg.color,fullAlpha,gameoverSpeed * Time.deltaTime);
			}
			//LXQ....
			if (!isDead) 
			{
				deathCanvas.SetActive(false);
				Gover = false;
			}

			
			PlayerInfo.playerinfo.health = currentHealth;
			PlayerInfo.playerinfo.scene = Application.loadedLevelName;
			PlayerInfo.playerinfo.position = gameObject.transform.position;

			inventory.UpdateInventory ();
			foreach (CharacterSlot characterSlot in characterSlots) {
				characterSlot.UpdateCharacterSlot();
			}
		}
		
		public void TakeDamage (int amount)
		{
			damaged = true;
			//determine which enemy attacks you according to the amount value
			if (amount == 11) {//zombie
				amount-=resistency_zombie;
			}

			else if (amount == 10) {//fantasy & boss
				amount-=resistency_fantasy;
			}

			else if (amount == 9) {//alien
				amount-=resistency_alien;
			}

			else if (amount == 30){
				amount -= (resistency_fantasy + resistency_alien + resistency_zombie);
			}

			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Standing_Block_Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Standing_Block_React_Large")) {
				amount = 1;
			}

			if (!isDead) {
				currentHealth -= amount;
				DamagePopUp.ShowMessage("-" + amount.ToString(), transform.position);
			}

//			anim.SetTrigger ("Hit");
			anim.SetBool ("InBattle", true);
	//		healthSlider.value = currentHealth;
			playerAudio.clip = hitClip[Random.Range (0, hitClip.Length)];
			playerAudio.Play ();
			if(currentHealth <= 0 && !isDead)
			{
				isDead = true;
				anim.SetTrigger ("Death");
				playerAudio.clip = deathClip[Random.Range (0, deathClip.Length)];
				playerAudio.Play ();

//				Invoke("Death", 4f);
				Invoke ("Gameover",2f);
				Invoke("Death", 12f);
			}
		}


		/*should not be here*/
//		public void AccumulateHtHealth(int amount)
//		{
//			if (currentHealth + amount >= startingHealth)
//				currentHealth = startingHealth;
//			else
//				currentHealth += amount;
//			
//		}

		//lxq
		void Gameover()
		{
			gameoverScreen.SetActive(true);
			Gover = true;
		}
		
		void Death ()
		{

	//		playerMovement.enabled = false;
			deathCanvas.SetActive (true);
			Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		}

		public void Restart() {
			deathCanvas.SetActive (false);

			//lxq
			gameoverScreen.SetActive(false);
			gameoverImg.color = zeroAlpha;
			Gover = false;

			currentHealth = startingHealth;
//			Application.LoadLevel("MenuScene");
			Time.timeScale = Time.timeScale == 0 ? 1 : 0;
		}
	}
}