using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundPillowMove : MonoBehaviour {

	[SerializeField]float speedDelay = 0.5f;

	float speed = 1.0f;
	Vector3 direction = new Vector3 (0, 0, 0);
	bool onMove = false;

	public void startMove(Vector3 iDirection, float iSpeed){
		//this.transform.rotation = this.transform.parent.rotation;
		speed = iSpeed * speedDelay;
		direction = iDirection;
		onMove = true;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (onMove) {
			this.transform.Translate (direction * speed * Time.deltaTime);
		}
	}
}
