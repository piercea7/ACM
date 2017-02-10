using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FighterKen : BaseFighter {


	/*Stats for hero (For your convenience)
	public int Health = 1000;                             // health all characters will have 1000 hp
	public float Agility = 5.0f;                          // handles the jumps and kneeling
	public float speed = 5.0f;                            // the speed of the player
	public float Defense = 1.0f;                          // Reduces the damage by this percent
	public int[] AttackPower = new int[7];
	public const int NumberOfCombos = 5;                  // this is more of a reminder of how much combos everyone has.
	public PlayerSize playerSize = PlayerSize.Normal;     // the size of the player (large, Small, Normal)
	/******************/

	 KeyCombo falconPunch = new KeyCombo(); 
	 KeyCombo falconKick = new KeyCombo();
	public override void StartVars ()
	{	
		//Handles inting vars
		base.StartVars ();
		
		falconPunch = new KeyCombo(new string[] {"down", "right","right"}, Controls);
		falconKick = new KeyCombo(new string[] {"down", "right","strong"}, Controls);
	}

	public override void UpdateFighter ()
	{
		//Handles Movement of fighter
		base.UpdateFighter (); 
		if (falconPunch.Check())
		{
			Debug.Log("TEST");
		}	
	}

	//This is how damage is done BY you
	//parm Col: the box that was hit with
	public override void HitMade (Collision2D col)
	{
		HealthSystem.UpdateHealth();
		base.HitMade(col);
		//Debug.Log ("Take That " + col.gameObject.tag);
	}
	
	//This is how damage is done TO you
	public override void DealDamageToSelf (float attackPower)
	{
		base.DealDamageToSelf (attackPower);
		//Debug.Log ("That Hurt:" + attackPower.ToString());
		Health -= attackPower / (2 * Defense);
		
		if(Health <= 0)
			Health = 0f;
	}
}

