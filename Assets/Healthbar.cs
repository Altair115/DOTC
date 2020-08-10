using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour {

	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public Slider healthSlider;									// Reference to the UI's health bar.

	public int Damage;
	
	void Awake () {
		// Set the initial health of the player.
		currentHealth = startingHealth;
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Peon")
		{
			Damage = 1;
			currentHealth -= Damage;						// Reduce the current health by the damage amount.
			healthSlider.value = currentHealth;				// Set the health bar's value to the current health.
		}
		if(other.gameObject.tag == "Grunt")
		{
			Damage = 5;
			currentHealth -= Damage;						// Reduce the current health by the damage amount.
			healthSlider.value = currentHealth;				// Set the health bar's value to the current health.
		}
		if(other.gameObject.tag == "Lord")
		{
			Damage = 10;
			currentHealth -= Damage;						// Reduce the current health by the damage amount.
			healthSlider.value = currentHealth;				// Set the health bar's value to the current health.
		}
	}
}
