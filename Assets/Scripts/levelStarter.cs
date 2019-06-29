using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelStarter : MonoBehaviour {

	public string sceneName;
	// Use this for initialization
	void Start () {
		
	}

	public void startScene(){
		SceneManager.LoadScene (sceneName);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
