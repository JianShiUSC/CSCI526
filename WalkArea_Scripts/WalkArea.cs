using UnityEngine;
using System.Collections;
namespace ThirdPersonRPG.Player 
{
	public class WalkArea : MonoBehaviour 
	{
		float xx = 0f,zz=0f,yy=0f;
		float z1=0f,z2=0f,x1=0f,x2=0f;
		Vector3 zero=new Vector3(0,0,0);
		Rigidbody rb;
		float force=280.0f;
		Animator ani;
		string scene;
		
		// Use this for initialization
		void Start () {
			rb = GetComponent<Rigidbody>();
			ani = GetComponent<Animator> ();
			scene = Application.loadedLevelName;

			Debug.Log (scene);

		}
		void whichScenen(string Scene)
		{

			if (Scene == "Demo4") {
				walk (-130,300,-300,90);
			}
			if (Scene == "Demo6") {
//				walk (-30.65f,30.22f,-30.2f,30.22f);
				walk (-90,90,-90,90);
			}
			if (Scene == "Demo7") {
				walk2 ();
			}

			if (Scene == "Demo8") {
				walk (20,70,40,90);
			}
		}
		
		// Update is called once per frame
		void Update () 
		{
			xx = transform.position.x;
			zz = transform.position.z;
			yy = transform.position.y;
			whichScenen (scene);
			 
		}
		public void walk(float Z1,float Z2,float X1,float X2){
			if (zz > Z1 && zz < Z2) {
				if (xx <= X1) {
					rb.AddForce (new Vector3 (force, 0, 0), ForceMode.Acceleration);
					ani.SetBool ("isBack", true);
				} else if (xx <= X2) {
					ani.SetBool ("isBack", false);
				} else {//xx>30.22f
					ani.SetBool ("isBack", true);
					rb.AddForce (new Vector3 (-force, 0, 0), ForceMode.Acceleration);
				}
			} else {
				ani.SetBool ("isBack", true);
				if (zz <= Z1) {
					rb.AddForce (new Vector3 (0, 0, force), ForceMode.Acceleration);
					
				} else {//zz>=30.22
					rb.AddForce (new Vector3 (0, 0, -force), ForceMode.Acceleration);
				}
			}
		}
		public void walk2()
		{
			if (yy <= 1f) {
				if (zz > -12 && zz < 55) {
					if (xx <= -26f) {
						//idle, add back force
						//					P.enabled = false;
						rb.AddForce (new Vector3 (force, 0, 0), ForceMode.Acceleration);
						ani.SetBool ("isBack", true);
					} else if (xx <= 48f) {
						//do nothing
						//					P.enabled = true;
						ani.SetBool ("isBack", false);
					} else {
						//idle, add force
						//					P.enabled = false;
						//					Debug.Log("back");
						ani.SetBool ("isBack", true);
						rb.AddForce (new Vector3 (-force, 0, 0), ForceMode.Acceleration);
					}
				} else {
					ani.SetBool ("isBack", true);
					if (zz <= -12) {
						rb.AddForce (new Vector3 (0, 0, force), ForceMode.Acceleration);
						
					} else {
						rb.AddForce (new Vector3 (0, 0, -force), ForceMode.Acceleration);
						
					}
					
				}
			} else if (yy < 9f && yy > 1f) 
			{
				if(zz>-16.3f && zz<60f)
				{
					if (xx <= -26f) {
						//idle, add back force
						//					P.enabled = false;
						rb.AddForce (new Vector3 (force, 0, 0), ForceMode.Acceleration);
						ani.SetBool ("isBack", true);
					} else if (xx <= 48f) {
						//do nothing
						//					P.enabled = true;
						ani.SetBool ("isBack", false);
					} else {
						//idle, add force
						//					P.enabled = false;
						//					Debug.Log("back");
						ani.SetBool ("isBack", true);
						rb.AddForce (new Vector3 (-force, 0, 0), ForceMode.Acceleration);
					}
					
					
				}else{
					ani.SetBool ("isBack", true);
					if (zz <= -16.3) {
						rb.AddForce (new Vector3 (0, 0, force), ForceMode.Acceleration);
						
					} else {
						rb.AddForce (new Vector3 (0, 0, -force), ForceMode.Acceleration);
						
					}
				}
				
			} else{//yy>=9
				//				floor2 part1
				if(zz>88.2f)
				{
					if (xx < -26.39f ) 
					{
						ani.SetBool ("isBack", true);
						rb.AddForce (new Vector3 (force, 0, 0), ForceMode.Acceleration);
					} else if(xx<-13.2f){
						ani.SetBool ("isBack", false);
					} else{//>-13.9
						ani.SetBool ("isBack", true);
						rb.AddForce (new Vector3 (-force, 0, 0), ForceMode.Acceleration);
					}
				}
				else if(46f<=zz&&zz<=88.2) //	floor2 part2
				{
					if (xx < -21.81f ) 
					{
						ani.SetBool ("isBack", true);
						rb.AddForce (new Vector3 (force, 0, 0), ForceMode.Acceleration);
					} else if(xx<-18.2f){
						ani.SetBool ("isBack", false);
					} else{//>-18.12
						ani.SetBool ("isBack", true);
						rb.AddForce (new Vector3 (-force, 0, 0), ForceMode.Acceleration);
					}
				} else { //zz<46f
					if (xx < -26.5f ) 
					{
						ani.SetBool ("isBack", true);
						rb.AddForce (new Vector3 (force, 0, 0), ForceMode.Acceleration);
					} else{//>-26.5
						ani.SetBool ("isBack", false);
					}
				}
			}

		}
	}
}
