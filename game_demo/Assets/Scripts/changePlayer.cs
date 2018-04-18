using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePlayer : MonoBehaviour {

	public Sprite manLeft;
	public Sprite manRight;

	float timer = 3f;
	float delay = 3f;

	void Start(){
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = manLeft;
	}

	void Update(){

		timer = timer - Time.deltaTime;
		if(timer < 0){
			if (this.gameObject.GetComponent<SpriteRenderer>().sprite == manLeft) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = manRight;
				timer = delay; //resetting the timer
				return;
			}
			if (this.gameObject.GetComponent<SpriteRenderer> ().sprite == manRight) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = manLeft;
				timer = delay; //resetting the timer
				return;
			}

		}

	}
}

