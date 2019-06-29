using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamCTRL : MonoBehaviour {

	[SerializeField]List<GameObject> listHero;
	[SerializeField]KeyCode keySwitch = KeyCode.Q;

	GameObject currentHero;
	int index;
	int total;
	int alive;

	public void heroDeath(){
		alive -= 1;
		if (alive == 0) {
			SceneManager.LoadScene ("sceneFinish");
		}
	}

	// Use this for initialization
	void Start () {
		foreach (GameObject go in listHero) {
			go.GetComponent<CharacterCTRL> ().OffSelect ();
		}
		if (listHero != null) {
			currentHero = listHero [0];
			currentHero.GetComponent<CharacterCTRL> ().OnSelect ();
			index = 0;
			total = listHero.Count;
			alive = total;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (keySwitch)) {
			currentHero.GetComponent<CharacterCTRL> ().OffSelect ();
			index = (index + 1) % total;
			currentHero = listHero [index];
			currentHero.GetComponent<CharacterCTRL> ().OnSelect ();
		}
	}
}
