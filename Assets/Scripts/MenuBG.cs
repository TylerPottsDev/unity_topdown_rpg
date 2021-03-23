using UnityEngine;
using UnityEngine.UI;

public class MenuBG : MonoBehaviour {
	Vector2 pz;
	Vector2 StartPos;
	[SerializeField] int moveModifier;

	void Start() {
		StartPos = transform.position;
	}

	void Update() {
		Vector2 pz = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		// gameObject.transform.position = pz;

		float posX = Mathf.Lerp(transform.position.x, StartPos.x + (pz.x * moveModifier), 2f * Time.deltaTime);
		float posY = Mathf.Lerp(transform.position.y, StartPos.y + (pz.y * moveModifier), 2f * Time.deltaTime);

		transform.position = new Vector3(
			posX, 
			posY, 
			0
		);
	}
}
