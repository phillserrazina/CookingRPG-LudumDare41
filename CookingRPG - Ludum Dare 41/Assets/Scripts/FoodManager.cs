using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour {

	// VARIABLES

	private Player player;
	private TurnStateManager turnManager;

	public enum Ingredients
	{
		STARTERS,
		SIDES,
		MAIN,
		DESERT
	};

	// METHODS

	void Start()
	{
		player = FindObjectOfType<Player> ();
		turnManager = FindObjectOfType<TurnStateManager> ();
	}

	public void BuyStarters()
	{
		if(player.money >= 2)
		{
			player.inventory.Add (FoodManager.Ingredients.STARTERS);
			player.money -= 2;
			turnManager.turnEnded = true;
		}
	}

	public void BuySides()
	{
		if(player.money >= 3)
		{
			player.inventory.Add (FoodManager.Ingredients.SIDES);
			player.money -= 3;
			turnManager.turnEnded = true;
		}
	}

	public void BuyMain()
	{
		if(player.money >= 5)
		{
			player.inventory.Add (FoodManager.Ingredients.MAIN);
			player.money -= 5;
			turnManager.turnEnded = true;
		}
	}

	public void BuyDesert()
	{
		if(player.money >= 3)
		{
			player.inventory.Add (FoodManager.Ingredients.DESERT);
			player.money -= 3;
			turnManager.turnEnded = true;
		}
	}

	public string MixIngredients(string i1, string i2)
	{
		string i3;

		i3 = i1 + i2;

		return i3;
	}
}
