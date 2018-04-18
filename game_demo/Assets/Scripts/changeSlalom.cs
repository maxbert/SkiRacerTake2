using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSlalom : MonoBehaviour {

	public Sprite RedSlalom;
	public Sprite BlueSlalom;

	float timer = 0.5f;
	float delay = 0.5f;

	void Start(){
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = RedSlalom;
	}

	void Update(){

		timer = timer - Time.deltaTime;
		if(timer < 0){
			if (this.gameObject.GetComponent<SpriteRenderer>().sprite == RedSlalom) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = BlueSlalom;
				timer = delay; //resetting the timer
				return;
			}
			if (this.gameObject.GetComponent<SpriteRenderer> ().sprite == BlueSlalom) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = RedSlalom;
				timer = delay; //resetting the timer
				return;
			}

	}

}
}

