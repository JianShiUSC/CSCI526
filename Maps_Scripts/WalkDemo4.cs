using UnityEngine;
using System.Collections;
namespace ThirdPersonRPG.Player 
{
	public class WalkDemo4 : MonoBehaviour 
	{
		float xx = 0f,zz=0f,yy=0f;
		Vector3 zero=new Vector3(0,0,0);
		Rigidbody rb;
		float force=280.0f;
		Animator ani;
		
		// Use this for initialization
		void Start () {
			rb = GetComponent<Rigidbody>();
			ani = GetComponent<Animator> ();
		}
		
		// Update is called once per frame
		void Update () 
		{
			xx= transform.position.x;
			zz = transform.position.z;
			yy = transform.position.y;
			
			
			if (zz > -100 && zz < 100)
			{
				if (xx <= -130f) {
					rb.AddForce (new Vector3 (force, 0, 0), ForceMode.Acceleration);
					ani.SetBool ("isBack", true);
				} else if (xx <= 70f) {
					ani.SetBool ("isBack", false);
				} else {//xx>70f
					ani.SetBool ("isBack", true);
					rb.AddForce (new Vector3 (-force, 0, 0), ForceMode.Acceleration);
				}
			} else {
				ani.SetBool ("isBack", true);
				if (zz <= -100) {
					rb.AddForce (new Vector3 (0, 0, force), ForceMode.Acceleration);
					
				} else {//zz>=100
					rb.AddForce (new Vector3 (0, 0, -force), ForceMode.Acceleration);
				}
			}
		}
	}
}
