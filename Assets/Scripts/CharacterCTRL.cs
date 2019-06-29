using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCTRL : MonoBehaviour {

	public int maxHealth = 100;
	public int maxMana = 100;

	public int health = 100;
	public int mana = 100;

	public bool actionAble = true;

	[SerializeField]bool isSelected = false;
	//Vector3 moveDirection;

	//[SerializeField]float moveSpeed = 1.0f;
	//[SerializeField]float turnSpeed = 15.0f;

	[SerializeField]KeyCode keySkill01 = KeyCode.Alpha1;
	[SerializeField]KeyCode keySkill02 = KeyCode.Alpha2;
	[SerializeField]KeyCode keySkill03 = KeyCode.Alpha3;

	[SerializeField]List<CharacterSkill> listSkill;
	[SerializeField]GameObject skillPlane;
	[SerializeField]Image imgHealth;
	[SerializeField]GameObject imgSelect;
	[SerializeField]GameObject imgEmotion;

	public bool OnSelect(){
		isSelected = true;
		imgSelect.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 1);
		foreach (Image img in skillPlane.GetComponentsInChildren<Image>()) {
			if (img.tag == "skillMask") 
				img.color = new Color (0f, 0f, 0f, 0.8f);
			else
				img.color = new Color (1, 1, 1, 1);
		}

		return true;
	}

	public void OffSelect(){
		isSelected = false;
		imgSelect.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
		SelectSkill (null);
		foreach (Image img in skillPlane.GetComponentsInChildren<Image>()) {
			//if (img.tag != "skillMask") 
				img.color = new Color (1, 1, 1, 0);
		}
	}

	public bool SelectSkill(CharacterSkill skill){
		if (actionAble) {
			foreach (CharacterSkill iSkill in listSkill) {
				iSkill.Unselect ();
			}
			if (skill == null)
				return false;
			return skill.OnSelect (this);
		}
		return false;
	}

	public void GetHit(int damage){
		imgEmotion.GetComponent<emotionCTRL> ().show ();
		health -= damage;
		if (health <= 0) {
			Death ();
		}
	}

	void UIrefresh(){
		imgHealth.fillAmount = (float)health / maxHealth;
	}

	private void Death(){
		if (actionAble) {
			SelectSkill (null);
			actionAble = false;
			imgEmotion.GetComponent<emotionCTRL> ().show (255f);
			this.GetComponentInParent<TeamCTRL> ().heroDeath ();
		}
		//OffSelect();
		//Destroy (this, 3f);
	}

	// Use this for initialization
	void Start () {
		//moveDirection = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		UIrefresh ();

		if (isSelected) {
			if (Input.GetKeyDown (keySkill01)) {
				SelectSkill (listSkill [0]);
			} else if (Input.GetKeyDown (keySkill02)) {
				SelectSkill (listSkill [1]);
			} else if (Input.GetKeyDown (keySkill03)) {
				SelectSkill (listSkill [2]);
			} 
		}
		
	}
}
