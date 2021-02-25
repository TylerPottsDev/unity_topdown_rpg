using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {
	[SerializeField] GameObject ArrowPrefab;
    [SerializeField] SpriteRenderer ArrowGFX;
	[SerializeField] Slider BowPowerSlider;
	[SerializeField] Transform Bow;
	
	[Range(0, 10)]
	[SerializeField] float BowPower;
	
	[Range(0, 3)]
	[SerializeField] float MaxBowCharge;
	float BowCharge = 0f;
	bool CanFire = true;

	private void Start() {
		BowPowerSlider.value = 0f;
		BowPowerSlider.maxValue = MaxBowCharge;
	}

	private void Update() {
		if (Input.GetMouseButton(0) && CanFire) {
			ChargeBow();
		} else if (Input.GetMouseButtonUp(0) && CanFire) {
			FireBow();
		} else {
			if (BowCharge > 0f) {
				BowCharge -= 0.1f;
			} else {
				BowCharge = 0f;
				CanFire = true;
			}

			BowPowerSlider.value = BowCharge;
		}
	}

	private void ChargeBow() {
		ArrowGFX.enabled = true;
		BowCharge += Time.deltaTime;

		BowPowerSlider.value = BowCharge;

		if (BowCharge > MaxBowCharge) {
			BowPowerSlider.value = MaxBowCharge;
		}
	}

	private void FireBow() {
		if (BowCharge > MaxBowCharge) BowCharge = MaxBowCharge;
		
		float ArrowDamage = BowCharge * BowPower;
		float ArrowSpeed = BowCharge + BowPower;

		float angle = Utility.AngleTowardsMouse(Bow.position);
		Quaternion rot = Quaternion.Euler(new Vector3(Bow.rotation.x, Bow.rotation.y, angle - 90f));

		Arrow Arrow = Instantiate(ArrowPrefab, Bow.position, rot).GetComponent<Arrow>();
		Arrow.ArrowVelocity = ArrowSpeed;

		CanFire = false;
		ArrowGFX.enabled = false;
	}
}
