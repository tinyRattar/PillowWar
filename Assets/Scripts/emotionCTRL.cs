using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emotionCTRL : MonoBehaviour {

	[SerializeField]float fadeTime = 3.0f;
	[SerializeField]Sprite spDead;
	float timer = 0.0f;
	bool noFade = false;

	public void show(float time = 3.0f){
		timer = time;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (noFade) {
			;
		} else if (timer == 255) {
			this.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
			this.GetComponent<SpriteRenderer> ().sprite = spDead;
			noFade = true;
		} else if (timer > 0) {
			timer -= Time.deltaTime;
			this.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, timer / fadeTime);
		}
	}
}
