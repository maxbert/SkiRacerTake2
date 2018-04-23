using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Configuration : MonoBehaviour {

	private int counter = 1;
	public Text Breaths;

	public void playGame(){
        BreathsCount.BreathsPer = counter;
        SceneManager.LoadScene (1);
	}

	public void quitGame(){
		Application.Quit ();
	}

	public int getBreaths(){

		return counter;
	}

	public void decreaseBreaths(){

		if (counter == 1) {
			counter = 1;
		} else {
			counter--;
		}

		Breaths.text = counter.ToString();

	}

	public void increaseBreaths(){
		
		if (counter < 100) {
			counter++;
		}
			
		Breaths.text = counter.ToString();
	}
}
