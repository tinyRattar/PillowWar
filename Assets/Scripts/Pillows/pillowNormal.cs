using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillowNormal : MonoBehaviour {

	[SerializeField]float maxSpeed = 5.0f;
	[SerializeField]float flyTime = 3.0f;
	[SerializeField]bool onFly = false;
	[SerializeField]int damage = 20;
	[SerializeField]GameObject hitEffect;
	[SerializeField]int bounceTime = 0;
	[SerializeField]float bounceSpeedDelay = 0.6f;
	[SerializeField]float bounceTimeDelay = 0.8f;

	float speed;
	float flyTimer = 0.0f;
	float topScaleMulti = 2f;
	Vector3 direction = new Vector3 (0, 0, 0);
	Vector3 bottomScale;
	//Vector3 topScale = new Vector3 (1.5f, 1.5f, 1);
	List<GameObject> hitList;


	public void OnShoot(Vector3 iDirection,float chargeScale){
		
		speed = maxSpeed * chargeScale;
		direction = iDirection;
		onFly = true;
	}

	void OnGround(){
		
		foreach (GameObject go in hitList) {
			go.GetComponent<CharacterCTRL> ().GetHit (damage);
		}
		hitEffect.transform.position = this.transform.position;
		GameObject newEffect = GameObject.Instantiate (hitEffect);
		if (bounceTime <= 0) {
			onFly = false;
			this.GetComponentInChildren<Animator> ().SetBool ("FadeOut", true);
			this.GetComponentInChildren<groundPillowMove> ().startMove (direction, speed);
			Destroy (this.gameObject, 3f);
		} else {
			bounceTime--;
			speed = speed * bounceSpeedDelay;
			flyTime *= bounceTimeDelay;
			topScaleMulti = (topScaleMulti - 1f) * bounceTimeDelay + 1f;
			flyTimer = 0f;
		}
	}
	// Use this for initialization
	void Start () {
		hitList = new List<GameObject> ();
		bottomScale = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if (onFly) {
			flyTimer += Time.deltaTime;
			this.transform.Translate (direction * speed * Time.deltaTime);
			if (flyTimer <= (flyTime / 2))
				this.transform.localScale = Vector3.Lerp (bottomScale, topScaleMulti * bottomScale, flyTimer * 2 / flyTime);
			else
				this.transform.localScale = Vector3.Lerp (topScaleMulti * bottomScale, bottomScale, flyTimer * 2 / flyTime - 1f);
			if (flyTimer >= flyTime) {
				//onFly = false;
				OnGround ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log (other.name);
		if (other.tag == "Player") {
			hitList.Add (other.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		//Debug.Log (other.name);
		if (other.tag == "Player") {
			hitList.Remove (other.gameObject);
		}
	}


}
