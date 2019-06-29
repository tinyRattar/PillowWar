using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkColliderChild : MonoBehaviour {

	[SerializeField]string direction;
	checkCollider checker;
	// Use this for initialization
	void Start () {
		checker = this.GetComponentInParent<checkCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log (other.name);
		if (other.tag == "Player") {
			checker.setCheck (direction, false);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		//Debug.Log (other.name);
		if (other.tag == "Player") {
			checker.setCheck (direction, true);
		}
	}
}
