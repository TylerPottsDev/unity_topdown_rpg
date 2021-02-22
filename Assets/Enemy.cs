using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	
	public float speed = 3f;
	[SerializeField] private float attackDamage = 10f;
	[SerializeField] private float attackSpeed = 1f;
	private float canAttack;

	private Transform target;

	private void Update() {
		if (target != null) {
			float step = speed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(transform.position, target.position, step);
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
