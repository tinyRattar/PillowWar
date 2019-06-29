using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillBigPillow : skillNormalPillow {

	// Use this for initialization
	void Start () {
		if (skillName == "UnKnown Skill") {
			skillName = "Big Pillow";
			cost = 0;
			cooldown = 15.0f;
		}
		imgArrow.fillAmount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		UIrefresh ();
		if (cdTimer > 0)
			cdTimer -= Time.deltaTime;
		if (isSelect) {
			if (onCharging) {
				if (Input.GetKey (keyFire)) {
					chargeScale += Time.deltaTime / fullChargeTime;
					if (chargeScale >= 1.0f) {
						chargeScale = 1.0f;
						OnCast ();
					}
				} else {
					OnCast ();
				}
			} else {
				if (Input.GetKey (keyUp)) {
					//arrow up
					aimArrow.transform.Rotate (new Vector3 (0, 0, Time.deltaTime * 45.0f));
				} else if (Input.GetKey (keyDown)) {
					//arrow down
					aimArrow.transform.Rotate (new Vector3 (0, 0, Time.deltaTime * -45.0f));
				} else if (Input.GetKeyDown (keyFire)) {
					chargeScale = 0.0f;
					onCharging = true;
				}
			}
		}
	}
}
