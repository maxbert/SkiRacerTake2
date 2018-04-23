using UnityEngine;
using UnityEngine.UI;
using Fizzyo;
using TMPro;


public class PlayerControl : MonoBehaviour {

	public float speed = 7;
	float screenHalfWidth;
    public GameObject StreakText;
    public GameObject OuchText;
    public Text Points;
    private SpriteRenderer spriteR;
    private int score;
    public int left;
    bool prevSpace;
    public int counter;
    public event System.Action OnGameOver;
    int breathsPer;
    int breaths;
    public Sprite leftGuy;
    public Sprite rightGuy;
    public bool isConfig;

    void Start () {
        score = 0;
        breaths = 0;
        breathsPer = BreathsCount.BreathsPer;
        FizzyoFramework.Instance.Recogniser.BreathStarted += OnBreathStarted;
        FizzyoFramework.Instance.Recogniser.BreathComplete += OnBreathEnded;
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


    void OnBreathStarted(object sender)
    {
        Debug.Log("Breath started");
    }

    void OnBreathEnded(object sender, ExhalationCompleteEventArgs e)
    {
        breaths++;
        
    }

    public void SetBreathsPer(int breathes)
    {
        this.breathsPer = breathes;
    }
    // Update is called once per frame
    void Update () {
        print(breathsPer);
        if(isConfig){
            left = 0;
        }

        if (breathsPer < breaths)
        {
        
            if (OnGameOver != null)
            {
                OnGameOver();
            }
        }

        speed = 7 * Difficulty.GetDifficultyPercent(this.counter) + 3;
        bool space = FizzyoFramework.Instance.Device.ButtonDown();
        if (space != prevSpace && space != false)
        {
            left = left * -1;
           
        }
        prevSpace = space;
        if(left > 0)
        {
            spriteR.sprite = leftGuy;
        }
        else
        {
            spriteR.sprite = rightGuy;
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
            isConfig = true;
            Points.color = new Color(0, 0, 0);
        }
        else
        {
            isConfig = false;
        }

        


        if(triggerCollider.tag == "Finish")
        {
            score += 1;
            counter = counter + 1;
            if (counter > 4)
            {
                Vector2 spawnPosition = new Vector2(this.transform.position.x, this.transform.position.y);
                GameObject streakTextBox = (GameObject)Instantiate(StreakText, spawnPosition, Quaternion.identity);
                TextMesh theText = streakTextBox.transform.GetComponent<TextMesh>();
                theText.text = counter.ToString();
                score = score + counter - 2;
                Points.color = new Color(1f, .17f, 0.0f);
                //FallingObstacles.Start ();
            }
            //Points.text = score.ToString();
            Points.text = score.ToString();
        }
        else if (triggerCollider.tag == "Out")
        {
            counter = 2;
            Points.color = new Color(0, 0, 0);
            Points.text = score.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            counter = 0;
            Vector2 spawnPosition = new Vector2(this.transform.position.x, this.transform.position.y);
            GameObject streakTextBox = (GameObject)Instantiate(StreakText, spawnPosition, Quaternion.identity);
            TextMesh theText = streakTextBox.transform.GetComponent<TextMesh>();
            theText.text = "ouch";
            Points.color = new Color(0, 0, 0);

        }
    }
}
		 

