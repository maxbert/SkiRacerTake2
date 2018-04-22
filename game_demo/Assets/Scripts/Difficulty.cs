using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty{

	static float secondsToMax = 8;

	public static float GetDifficultyPercent(int counter){

        return Mathf.Clamp01 (counter / secondsToMax);
	}
}
