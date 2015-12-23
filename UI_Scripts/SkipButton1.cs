using UnityEngine;
using System.Collections;

public class SkipButton1 : MonoBehaviour 
{
	public GameObject StartText;
	public GameObject JumpText;
	public GameObject BlockText;
	public GameObject BurningText;
	public GameObject StormText;
	public GameObject LightText;
	public GameObject SpecialText;
	public GameObject ComboText;
	public GameObject panel;
	public GameObject levelup;

	//public GameObject start;
	public GameObject jump;
	public GameObject block;
	public GameObject burning;
	public GameObject storm;
	public GameObject light;
	public GameObject special;
	public GameObject combo;

	public GameObject control;
	public GameObject camera;
	public GameObject task;

	int count = 0;

	public void Start()
	{
		StartText.SetActive(true);
		JumpText.SetActive (false);
		BlockText.SetActive (false);
		BurningText.SetActive (false);
		StormText.SetActive (false);
		LightText.SetActive (false);
		SpecialText.SetActive (false);
		ComboText.SetActive (false);
	}

	public void skip()
	{
		++count;
		if (count == 1) 
		{
			StartText.SetActive(false);
			JumpText.SetActive (true);
			BlockText.SetActive (false);
			BurningText.SetActive (false);
			StormText.SetActive (false);
			LightText.SetActive (false);
			SpecialText.SetActive (false);
			ComboText.SetActive (false);
			
			jump.SetActive (true);
			block.SetActive (false);
			burning.SetActive (false);
			storm.SetActive (false);
			light.SetActive (false);
			special.SetActive (false);
			combo.SetActive(false);
			//control.SetActive (false);
			camera.SetActive (false);
			task.SetActive (false);
		}

		if (count == 2) 
		{
			StartText.SetActive(false);
			JumpText.SetActive (false);
			BlockText.SetActive (true);
			BurningText.SetActive (false);
			StormText.SetActive (false);
			LightText.SetActive (false);
			SpecialText.SetActive (false);
			ComboText.SetActive (false);

			jump.SetActive (false);
			block.SetActive (true);
			burning.SetActive (false);
			storm.SetActive (false);
			light.SetActive (false);
			special.SetActive (false);
			combo.SetActive(false);
			//control.SetActive (false);
			camera.SetActive (false);
			task.SetActive (false);
		}
		if (count == 3) 
		{
			StartText.SetActive(false);
			JumpText.SetActive (false);
			BlockText.SetActive (false);
			BurningText.SetActive (true);
			StormText.SetActive (false);
			LightText.SetActive (false);
			SpecialText.SetActive (false);
			ComboText.SetActive (false);

			jump.SetActive (false);
			block.SetActive (false);
			burning.SetActive (true);
			storm.SetActive (false);
			light.SetActive (false);
			special.SetActive (false);
			combo.SetActive(false);
			//control.SetActive (false);
			camera.SetActive (false);
			task.SetActive (false);
		}
		if (count == 4) 
		{
			StartText.SetActive(false);
			JumpText.SetActive (false);
			BlockText.SetActive (false);
			BurningText.SetActive (false);
			StormText.SetActive (true);
			LightText.SetActive (false);
			SpecialText.SetActive (false);
			ComboText.SetActive (false);

			jump.SetActive (false);
			block.SetActive (false);
			burning.SetActive (false);
			storm.SetActive (true);
			light.SetActive (false);
			special.SetActive (false);
			combo.SetActive(false);
			//control.SetActive (false);
			camera.SetActive (false);
			task.SetActive (false);
		}
		if (count == 5) 
		{
			StartText.SetActive(false);
			JumpText.SetActive (false);
			BlockText.SetActive (false);
			BurningText.SetActive (false);
			StormText.SetActive (false);
			LightText.SetActive (true);
			SpecialText.SetActive (false);
			ComboText.SetActive (false);

			jump.SetActive (false);
			block.SetActive (false);
			burning.SetActive (false);
			storm.SetActive (false);
			light.SetActive (true);
			special.SetActive (false);
			combo.SetActive(false);
			//control.SetActive (false);
			camera.SetActive (false);
			task.SetActive (false);
		}
		if (count == 6) 
		{
			StartText.SetActive(false);
			JumpText.SetActive (false);
			BlockText.SetActive (false);
			BurningText.SetActive (false);
			StormText.SetActive (false);
			LightText.SetActive (false);
			SpecialText.SetActive (true);
			ComboText.SetActive (false);

			jump.SetActive (false);
			block.SetActive (false);
			burning.SetActive (false);
			storm.SetActive (false);
			light.SetActive (false);
			special.SetActive (true);
			combo.SetActive(false);
			//control.SetActive (false);
			camera.SetActive (false);
			task.SetActive (false);
		}
		if (count == 7) 
		{
			StartText.SetActive(false);
			JumpText.SetActive (false);
			BlockText.SetActive (false);
			BurningText.SetActive (false);
			StormText.SetActive (false);
			LightText.SetActive (false);
			SpecialText.SetActive (false);
			ComboText.SetActive (true);
			
			jump.SetActive (false);
			block.SetActive (false);
			burning.SetActive (false);
			storm.SetActive (false);
			light.SetActive (false);
			special.SetActive (false);
			combo.SetActive(true);
			//control.SetActive (false);
			camera.SetActive (false);
			task.SetActive (false);
		}

		if (count > 7) 
		{
			StartText.SetActive(false);
			JumpText.SetActive (false);
			BlockText.SetActive (false);
			BurningText.SetActive (false);
			StormText.SetActive (false);
			LightText.SetActive (false);
			SpecialText.SetActive (false);
			ComboText.SetActive (false);
			levelup.SetActive(false);
			panel.SetActive(false);

			jump.SetActive (true);
			block.SetActive (true);
			burning.SetActive (true);
			storm.SetActive (true);
			light.SetActive (true);
			special.SetActive (true);
			combo.SetActive(true);
			//control.SetActive (true);
			camera.SetActive (true);
			task.SetActive (true);
			Time.timeScale = 1;
		}
	}
}
