using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    private float health = 0f;
	[SerializeField] private float maxHealth = 100f;
	[SerializeField] private Slider healthSlider;

	private void Start() {
		health = maxHealth;
		healthSlider.maxValue = maxHealth;
	}

	public void UpdateHealth(float mod) {
		health += mod;

		if (health > maxHealth) {
			health = maxHealth;
		} else if (health <= 0f) {
			health = 0f;
			healthSlider.value = health;
			Destroy(gameObject);
		}
	}

	private void OnGUI() {
		float t = Time.deltaTime / 1f;
		healthSlider.value = Mathf.Lerp(healthSlider.value, health, t);
	}
}
