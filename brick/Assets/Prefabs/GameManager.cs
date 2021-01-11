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

    void Start()
    {
      livesText.text = "LIVES " + lives;
      scoreText.text = "SCORE " + score;
      // this allows the lives and score to be updated live on screen.
      numberofBricks = GameObject.FindGameObjectsWithTag("brick").Length;
    }


    void Update()
    {

    }

  public void UpdateLives(int changeInLives){
    lives += changeInLives;


    if (lives <= 0){
        lives = 0;
        GameOver ();
        // this makes the game over screen appear when you are out of lives.

    }
    livesText.text = "LIVES " + lives;
    //  this removes lives on screen when the ball falls off the bottom.
  }

  public void UpdateScore(int points){
    score += points;

    scoreText.text = "SCORE " + score;

    // this adds your score on screen.
  }

  void GameOver(){
    gameOver = true;
    gameOverText.SetActive (true);

  }


  public void UpdateNumberOfBricks(){
  numberofBricks --;
  if (numberofBricks <=0){
  GameOver ();
  // this brings the gameover screen when there are no bricks left on screen.

  }
}

  public void Again(){
  SceneManager.LoadScene("SampleScene");
  // this defines what happens when you press the Again button on the gameover screen: it resets the game.
  }

  public void Quit(){
    Application.Quit ();
    Debug.Log ("quit");
  // this defines what happens when you press the quit button on the gameover screen: It quits the game. There is a message put in the debug log so i could test it worked, as it cannot quit out on Unity.

  }
}
