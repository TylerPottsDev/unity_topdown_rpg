using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	[Header("Movement")]
	public float speed = 3f;
	[Header("Attack")]
	[SerializeField] private float attackDamage = 10f;
	[SerializeField] private float attackSpeed = 1f;
	private float canAttack;

	[Header("Health")]
	private float health;
	[SerializeField] private float maxHealth;

	private Transform target;

	private void Start() {
		health = maxHealth;
	}

	public void TakeDamage(float dmg) {
		health -= dmg;
		Debug.Log("Enemy Health: " + health);

		if (health <= 0) {
			Destroy(gameObject);
		}
	}

	private void FixedUpdate() {
		if (target != null) {
			float step = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, target.position, step);
		}
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			if (attackSpeed <= canAttack) {
				other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
				canAttack = 0f;
			} else {
				canAttack += Time.deltaTime;
			}
		}
	}

	private void OnCollisionStay2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			if (attackSpeed <= canAttack) {
				other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
				canAttack = 0f;
			} else {
				canAttack += Time.deltaTime;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			target = other.transform;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			target = null;
		}
	}
}
