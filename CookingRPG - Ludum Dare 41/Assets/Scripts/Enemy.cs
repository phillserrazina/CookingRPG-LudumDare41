using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// VARIABLES

	public int hp = 100;
	public int pp = 0;

	public enum Demands
	{
		VEGGIE,
		MEATY,
		KIDFRIENDLY,
	}

	public Demands demand1;
	public Demands demand2;

	private Player player;

	// METHODS

	void Start()
	{
		player = FindObjectOfType<Player> ();
	}
		
	// MOVES

	public void Complain()
	{
		player.motivation -= 10;
	}

	public void Yell()
	{
		player.motivation -= 20;
	}

	public void Humiliate()
	{
		player.motivation -= 50;
	}

	public void Wait()
	{
		pp += 40;
	}
}
