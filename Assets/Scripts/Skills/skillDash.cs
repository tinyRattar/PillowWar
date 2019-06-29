using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillDash : CharacterSkill {

	[SerializeField]KeyCode keyUp = KeyCode.W;
	[SerializeField]KeyCode keyDown = KeyCode.S;
	[SerializeField]KeyCode keyLeft = KeyCode.A;
	[SerializeField]KeyCode keyRight = KeyCode.D;

	[SerializeField]float stride = 1.0f;
	[SerializeField]checkCollider checker;

	Vector3 direction = new Vector3 (0, 0, 0);

	public override void OnCast ()
	{
		base.OnCast ();
		Vector3 checkVector = this.transform.localPosition + direction;
		//todo:border check
		if (checkVector.x >= 0 && checkVector.x <= 4 && checkVector.y >= -5 && checkVector.y <= 0) {
			this.transform.Translate (direction * stride);
		}
	}

	// Use this for initialization
	void Start () {
		skillName = "Dash";
		cost = 0;
		cooldown = 7.5f;
	}
	
	// Update is called once per frame
	void Update () {
		UIrefresh ();
		if (cdTimer > 0)
			cdTimer -= Time.deltaTime;
		if (isSelect) {
			if (Input.GetKeyDown (keyUp)) {
				direction = new Vector3 (0, 1, 0);
				if (!checker.isEmpty ("up")) 
					direction = new Vector3 (0, 0, 0);
				OnCast ();
			} else if (Input.GetKeyDown (keyDown)) {
				direction = new Vector3 (0, -1, 0);
				if (!checker.isEmpty ("down")) 
					direction = new Vector3 (0, 0, 0);
				OnCast ();
			} else if (Input.GetKeyDown (keyLeft)) {
				direction = new Vector3 (-1, 0, 0);
				if (!checker.isEmpty ("left")) 
					direction = new Vector3 (0, 0, 0);
				OnCast ();
			} else if (Input.GetKeyDown (keyRight)) {
				direction = new Vector3 (1, 0, 0);
				if (!checker.isEmpty ("right")) 
					direction = new Vector3 (0, 0, 0);
				OnCast ();
			}
		}
	}
}
