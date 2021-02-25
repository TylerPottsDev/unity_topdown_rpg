using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;

    public Rigidbody2D rb;
	[SerializeField] Transform hand;
	[SerializeField] GameObject arrow;

    Vector2 movement;

    void Update() {
        MovementInput();
		RotateHand();
    }

    private void FixedUpdate() {
        rb.velocity = movement * moveSpeed;
    }

	void RotateHand() {
		float angle = Utility.AngleTowardsMouse(hand.position);
		hand.rotation = Quaternion.Euler(new Vector3(hand.rotation.x, hand.rotation.y, angle));
	}

    void MovementInput () {
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");

        movement = new Vector2(mx, my).normalized;
    }
}
