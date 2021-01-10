using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{   public int lives;
    public int score;
    public Text livesText;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameOverText;
    public int numberofBricks;

    // Start is called before the first frame update
    void Start()
    {
      livesText.text = "LIVES " + lives;
      scoreText.text = "SCORE " + score;
      numberofBricks = GameObject.FindGameObjectsWithTag("brick").Length;
    }

    // Update is called once per frame
    void Update()
    {

    }

  public void UpdateLives(int changeInLives){
    lives += changeInLives;


    if (lives <= 0){
        lives = 0;
        GameOver ();

    }
    livesText.text = "LIVES " + lives;

  }

  public void UpdateScore(int points){
    score += points;

    scoreText.text = "SCORE " + score;
  }

  void GameOver(){
    gameOver = true;
    gameOverText.SetActive (true);

  }


  public void UpdateNumberOfBricks(){
  numberofBricks --;
  if (numberofBricks <=0){
  GameOver ();

  }
}

  public void Again(){
  SceneManager.LoadScene("SampleScene");

  }

  public void Quit(){
    Application.Quit ();
    Debug.Log ("so long");


  }
}
