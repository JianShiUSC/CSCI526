using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {

	private int health = 100;
	private int maxHealth = 100;
	public GameObject healthBarObj;
	private Image healthBar;
	private EnemyHealth eh;
	public Color MaxHealthColor = Color.green;
	public Color MinHealthColor = Color.red;
	public int counter = 100;
	
	// Use this for initialization
	void Start () {
//		healthBar = transform.FindChild ("EnemyCanvas").FindChild ("HealthBG").FindChild ("Health").GetComponent<Image> ();
		healthBar = healthBarObj.GetComponent<Image> ();
		eh = gameObject.GetComponent<EnemyHealth> ();
		health = eh.currentHealth;
		maxHealth = eh.startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		counter = eh.currentHealth;
		Hit (counter);
//		Debug.Log ("counter:  " + counter);
	}
	public void Hit(int currentHealth)
	{
		//health -= damage;
		healthBar.fillAmount = (float)currentHealth / (float)maxHealth;
		healthBar.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)currentHealth / maxHealth);
	}
}
