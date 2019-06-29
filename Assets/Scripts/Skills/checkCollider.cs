using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollider : MonoBehaviour {

	public bool up = true;
	public bool right = true;
	public bool down = true;
	public bool left = true;

	public bool isEmpty(string direction){
		switch (direction) {
		case "up":
			return up;
		case "right":
			return right;
		case "left":
			return left;
		case "down":
			return down;
		default:
			return false;
		}
	}

	public void setCheck(string direction,bool flag){
		switch (direction) {
		case "up":
			up = flag;
			break;
		case "right":
			right = flag;
			break;
		case "left":
			left = flag;
			break;
		case "down":
			down = flag;
			break;
		default:
			return;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
