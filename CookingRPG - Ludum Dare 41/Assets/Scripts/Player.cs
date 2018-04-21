using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// VARIABLES

	public int money = 0;
	public int damage = 20;
	public float motivation = 100;
	public List<FoodManager.Ingredients> inventory = new List<FoodManager.Ingredients> {};

	public string currentDish;

	private TurnStateManager turnManager;

	public Enemy activeEnemy;

	// METHODS

	void Start()
	{
		turnManager = FindObjectOfType<TurnStateManager> ();
	}

	// MOVES

	public void KidMenu()
	{
		if(turnManager.currentEnemy.demand1 == Enemy.Demands.KIDFRIENDLY)
		{
			damage += 30;
		}

		activeEnemy.hp -= damage;

		turnManager.turnEnded = true;
	}

	public void MeatMenu()
	{
		if(turnManager.currentEnemy.demand1 == Enemy.Demands.MEATY)
		{
			damage += 30;
		}

		if(turnManager.currentEnemy.demand1 == Enemy.Demands.VEGGIE)
		{
			damage -= 10;
		}

		activeEnemy.hp -= damage;

		turnManager.turnEnded = true;
	}

	public void VeggieMenu()
	{
		if(turnManager.currentEnemy.demand1 == Enemy.Demands.VEGGIE)
		{
			damage += 30;
		}

		if(turnManager.currentEnemy.demand1 == Enemy.Demands.MEATY)
		{
			damage -= 10;
		}

		activeEnemy.hp -= damage;

		turnManager.turnEnded = true;
	}

	public void Rest()
	{
		motivation += 50;
		turnManager.turnEnded = true;
	}
}
