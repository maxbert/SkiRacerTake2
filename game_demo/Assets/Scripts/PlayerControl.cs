using UnityEngine;
using UnityEngine.UI;


public class PlayerControl : MonoBehaviour {

	public float speed = 7;
	float screenHalfWidth;
    public Text Points;
    private SpriteRenderer spriteR;
    private int score;
    public int left;
    float prevSpace;
    public int counter;
    public event System.Action OnGameOver;
    int breathsPer;
    int breaths;

    void Start () {
        score = 0;
        counter = 2;
        left = -1;
		float halfPlayerWidth = transform.localScale.x / 2f;
		screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize - halfPlayerWidth;
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        Points.text = score.ToString();
	}

    int getScore()
    {
        return score;
    }
	// Update is called once per frame
	void Update () {

        if (breaths > breathsPer)
        {
            if (OnGameOver != null)
            {
                OnGameOver();
            }
        }

        speed = 7 * Difficulty.GetDifficultyPercent(this.counter) + 3; 
		float space = Input.GetAxisRaw ("Jump");
        if(space != prevSpace && space != 0)
        {
            left = left * -1;
           
        }
        prevSpace = space;
        if(left > 0)
        {
            spriteR.flipX = true;
        }
        else
        {
            spriteR.flipX = false;
        }
        float velocity = left * speed;
		transform.Translate (Vector2.right * velocity * Time.deltaTime);

		if (transform.position.x < -screenHalfWidth) {
			transform.position = new Vector2 (-screenHalfWidth, transform.position.y);
		}

		if (transform.position.x > screenHalfWidth) {
			transform.position = new Vector2 (screenHalfWidth, transform.position.y);
		}

	}

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
 

        if (triggerCollider.tag == "Avalanche")
        {
            counter = 0;
        }

        if (triggerCollider.tag == "Tree")
        {
            counter = 0;
            
        }


        if (triggerCollider.tag == "Finish")
        {
            score += 1;
            counter = counter + 1;
            if (counter > 4)
            {
                score = score + counter - 2;
                //FallingObstacles.Start ();
            }
            //Points.text = score.ToString();
			Points.text =  score.ToString();
        }
        else if(triggerCollider.tag == "Out")
        {
            counter = 2;
            Points.text =  score.ToString();
        }
    }
		 
}
