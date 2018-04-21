using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnStateManager : MonoBehaviour {

	// VARIABLES
	
	public GameObject buttonArea;
	public GameObject messageArea;
	public GameObject cookArea;
	public GameObject conArea;
	public GameObject storeArea;

	public Enemy[] enemyArray;
	public Enemy currentEnemy;
	public Enemy enemyObject;

	public bool turnEnded = false;

	public enum States
	{
		START,
		PLAYERCHOICE,
		ENEMYCHOICE,
		LOSE,
		WIN
	}

	public States currentState;

	private bool buttonsEnabled;

	private Player player;

	// METHODS

	void Start()
	{
		player = FindObjectOfType<Player> ();
		currentState = States.START;
	}

	void Update()
	{
		if(buttonsEnabled == true)
		{
			buttonArea.SetActive(true);
		}
		else if(buttonsEnabled == false)
		{
			buttonArea.SetActive(false);
		}

		switch(currentState)
		{
		case(States.START):
			// Reset Variables
			turnEnded = false;
			buttonsEnabled = false;

			// Reset HUD
			messageArea.SetActive (true);
			storeArea.SetActive (false);
			conArea.SetActive (false);
			cookArea.SetActive (false);

			// Generate new Enemy
			int newEnemy = Random.Range (0, 2);

			if(currentEnemy == null)
			{
				currentEnemy = enemyArray [newEnemy];
				enemyObject = Instantiate (currentEnemy);
				player.activeEnemy = enemyObject;
			}

			if(player.motivation <= 0)
			{
				currentState = States.LOSE;
			}

			currentState = States.PLAYERCHOICE;
			break;

		case(States.PLAYERCHOICE):
			buttonsEnabled = true;

			if(turnEnded == true)
			{
				currentState = States.ENEMYCHOICE;
			}

			break;

		case(States.ENEMYCHOICE):
			buttonsEnabled = false;

			if(enemyObject.hp <= 0)
			{
				Destroy (GameObject.FindGameObjectWithTag("Enemy"));
				currentEnemy = null;
			}

			else if(enemyObject.hp > 0)
			{
				// TODO: Everything
			}

			currentState = States.START;
			break;

		case(States.LOSE):
			break;

		case(States.WIN):
			break;
		}
	}

	public void Cook()
	{
		// Disable any visible area and enable Cook Area
		messageArea.SetActive(false);
		storeArea.SetActive (false);
		conArea.SetActive (false);
		cookArea.SetActive (true);
	}

	public void BuyIngredients()
	{
		// Disable any visible area and enable Cook Area
		messageArea.SetActive(false);
		storeArea.SetActive (true);
		conArea.SetActive (false);
		cookArea.SetActive (false);
	}

	public void ShowInventory()
	{
		// Disable any visible area and enable Cook Area
		messageArea.SetActive(true);
		storeArea.SetActive (false);
		conArea.SetActive (false);
		cookArea.SetActive (false);
	}

	public void GiveUp()
	{
		currentState = States.LOSE;
	}
}
