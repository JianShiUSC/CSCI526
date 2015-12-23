using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace ThirdPersonRPG.Player
{
	public class PlayerMagic : MonoBehaviour 
	{
		public GameObject magicBarObj;
		public int counter = 500;

		private int maxMagic;
		private Image magicBar;
		private PlayerAngryValue pav;

		// Use this for initialization
		void Start () {
			maxMagic = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerAngryValue>().maxAngryValue;
			magicBar = magicBarObj.GetComponent<Image> ();
			pav = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerAngryValue> ();
		}
		
		// Update is called once per frame
		void Update () {
			counter = pav.currentAngryValue;
			Fill (counter);
		}

		public void Fill(int currentAngryValue)
		{
			magicBar.fillAmount = (float)currentAngryValue / (float)maxMagic;
		}
	}
}