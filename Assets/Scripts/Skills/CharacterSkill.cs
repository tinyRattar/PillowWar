using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CharacterSkill : MonoBehaviour {

	public string skillName = "UnKnown Skill";
	public int cost = 0;
	public float cooldown = 1.0f;
	public bool isSelect = false;

	public float cdTimer = 0.0f;

	public Image imgSkill;
	public Image imgSkillBottom;

	public GameObject pfbSkillSelector;
	protected GameObject iSkillSelector;

	//abstract public void OnCast ();
	public virtual bool OnSelect(CharacterCTRL caster){
		if (cdTimer > 0f) {
			//Debug.Log ("cooldowning");
			return false;
		} else if (caster.mana < cost) {
			//Debug.Log ("no mana");
			return false;
		}

		if (iSkillSelector == null) {
			pfbSkillSelector.transform.position = imgSkillBottom.transform.position;
			iSkillSelector = GameObject.Instantiate (pfbSkillSelector);
		}

		isSelect = true;
		return true;
	}
	public virtual void Unselect(){
		isSelect = false;

		if (iSkillSelector != null) {
			Destroy (iSkillSelector);
			iSkillSelector = null;
		}
	}
	public virtual void OnCast(){
		CharacterCTRL caster;
		caster = this.GetComponent<CharacterCTRL> ();
		caster.mana -= cost;
		cdTimer = cooldown;
		Unselect ();
	}
	public virtual void UIrefresh(){
		imgSkill.fillAmount = 1 - cdTimer / cooldown;
		imgSkillBottom.fillAmount = cdTimer / cooldown;
	}

}
