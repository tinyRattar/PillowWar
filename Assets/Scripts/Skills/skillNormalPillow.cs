using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillNormalPillow : CharacterSkill {

	[SerializeField]protected KeyCode keyUp = KeyCode.W;
	[SerializeField]protected KeyCode keyDown = KeyCode.S;
	[SerializeField]protected KeyCode keyFire = KeyCode.Space;
	[SerializeField]protected float fullChargeTime = 1.0f;
	[SerializeField]protected GameObject pillow;
	[SerializeField]protected GameObject aimArrow;

	[SerializeField]protected Image imgArrow;

	protected bool onCharging = false;
	protected float chargeScale = 0.0f;

	public override void OnCast ()
	{
		base.OnCast ();
		onCharging = false;
		pillow.transform.position = this.transform.position;
		GameObject newPillow = GameObject.Instantiate (pillow);
		//Debug.Log (aimArrow.transform.up);
		newPillow.GetComponent<pillowNormal> ().OnShoot (aimArrow.transform.up, chargeScale);
		chargeScale = 0.0f;
		imgArrow.fillAmount = 0;
	}

	public override void UIrefresh ()
	{
		base.UIrefresh ();
		if (isSelect) {
			imgArrow.fillAmount = chargeScale;
		}
	}

	// Use this for initialization
	void Start () {
		if (skillName == "UnKnown Skill") {
			skillName = "Normal Pillow";
			cost = 0;
			cooldown = 5.0f;
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
