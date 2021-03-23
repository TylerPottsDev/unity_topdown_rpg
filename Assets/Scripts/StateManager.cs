using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour {

	public void ReloadCurrentScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
	public void ChangeSceneByName(string name = null) {
		if (name != null) {
			SceneManager.LoadScene(name);
		}
	}

}
