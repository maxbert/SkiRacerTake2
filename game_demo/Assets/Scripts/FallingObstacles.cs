using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacles : MonoBehaviour {

	public Vector2 speedMinMax;
	float speed;
    float visibleHeight;
    private bool original;

	void Start(){
        visibleHeight = Camera.main.orthographicSize - transform.localScale.y;
        original = false;
        PlayerControl player = FindObjectOfType<PlayerControl>();
        speed = Mathf.Lerp (speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent (player.counter));
	}

	void Update () {
        PlayerControl player = FindObjectOfType<PlayerControl>();
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent(player.counter));
        transform.Translate (Vector3.up * speed * Time.deltaTime);
        if(transform.position.y > visibleHeight + 2 * transform.localScale.y && !original)
        {
            original = true;
        }
        else if(transform.position.y > visibleHeight + 2 * transform.localScale.y)
        {
            Destroy(gameObject);
        }
	}
}
