using UnityEngine;
using System.Collections;

public class TrapAudio : MonoBehaviour {



	void OnTriggerEnter(Collider other)
	{
		AudioSource audio = GetComponent<AudioSource>();
		if(other.tag == "Player")
		audio.Play();
	}
	void OnTriggerExit(Collider other)
	{
		AudioSource audio = GetComponent<AudioSource>();
		if (other.tag == "Player")
			audio.Stop ();

	}
}
