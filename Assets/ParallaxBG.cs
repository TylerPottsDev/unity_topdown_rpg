using UnityEngine;

public class ParallaxBG : MonoBehaviour {
	Vector2 StartPos;
	[SerializeField] int moveModifier;

	private void Start() {
		StartPos = transform.position;
	}

	private void Update() {
		Vector2 pz = Camera.main.ScreenToViewportPoint(Input.mousePosition);

		float posX = Mathf.Lerp(transform.position.x, StartPos.x + (pz.x * moveModifier), 2f * Time.deltaTime);
		float posY = Mathf.Lerp(transform.position.y, StartPos.y + (pz.y * moveModifier), 2f * Time.deltaTime);

		transform.position = new Vector3(
			posX,
			posY,
			0
		);
	}
}
