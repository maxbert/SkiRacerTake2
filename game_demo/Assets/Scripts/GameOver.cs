using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fizzyo;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverScreen;
    public Text pointsScoredUI;
    public PlayerControl player;
    bool gameOver;

    void Start()
    {
        FindObjectOfType<PlayerControl>().OnGameOver += OnGameOver;
        gameOver = false;

    }

    void Update()
    {
        if (gameOver)
        {
            FizzyoFramework.Instance.Achievements.PostScore(int.Parse(player.Points.text));


        }
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        pointsScoredUI.text = player.Points.text;
        gameOver = true;
    }

	public void Restart(){
        gameOver = false;
		SceneManager.LoadScene (1);
	}
}
