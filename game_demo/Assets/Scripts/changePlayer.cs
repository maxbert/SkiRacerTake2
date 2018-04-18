/* learnt from this youtube tutorial : https://www.youtube.com/watch?v=1EJOYWBcrzQ */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour {

	public Sprite manLeft;
	public Sprite manRight; //switching in between sprites

	// be accessed outside of the class so we can modify when the player needs switching
	public float timer = 3f;
	public float delay = 3f;

	// initialize the starting sprite to at least one of them
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

