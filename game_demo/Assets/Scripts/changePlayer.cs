
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayer : MonoBehaviour {

	public Sprite manLeft;
	public Sprite manRight; //switching in between sprites


	// initialize the starting sprite to at least one of them
	void Start(){
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = manLeft;
	}

	void Update(){

		if(Input.GetKeyDown("space")){
			if (this.gameObject.GetComponent<SpriteRenderer>().sprite == manLeft) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = manRight;
				return;
			}
			if (this.gameObject.GetComponent<SpriteRenderer> ().sprite == manRight) {
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = manLeft;
				return;
			}

		}

	}
}

