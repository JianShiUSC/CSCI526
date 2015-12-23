using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {
	 
    public int currentcoins=0;
	public int currentbottle2=0;
	public int currentweapon=0;
	public int collecthealth=0;
	public int collectprotection = 0;
	
	
	public void collect_coins(int amount)
	{
		currentcoins += amount;
	}
	public void bottle2_energy(int amount)
	{
		currentbottle2 += amount;
	}
	public void collect_weapons(int amount)
	{
		currentweapon += amount;
	}
	public void collect_health(int amount)
	{
		collecthealth += amount;
	}
	public void collect_protection(int amount)
	{
		collectprotection += amount;
	}
}
