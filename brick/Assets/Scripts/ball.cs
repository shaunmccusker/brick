using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{

  public Rigidbody2D rb;
  public bool inPlay;
  public Transform paddle;
  public float speed;
  public Transform explode;
  public GameManager gamemanager;
  public AudioSource audio;



    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        audio = GetComponent<AudioSource> ();
    }


    void Update()
    {
      if (gamemanager.gameOver){
         return;

      }
      if(inPlay == false){
         transform.position = paddle.position;
         // this sets the reset point for the ball when it falls off the bottom
      }
      if(Input.GetButtonDown("Jump") && inPlay == false)  {
        inPlay = true;
        rb.AddForce(Vector2.up * speed);
        // this allows the spacebar to be used to start again after ball respawn
      }

    }


    void OnTriggerEnter2D(Collider2D other){
    if (other.CompareTag("Bottom")){
      rb.velocity = Vector2.zero;
      inPlay = false;
      gamemanager.UpdateLives(-1);
      // This resets the balls speed, position, and removes 1 life upon colliding with the bottom of the screen.
        }

    }

    void OnCollisionEnter2D(Collision2D other){
      if(other.transform.CompareTag("brick")){
        Transform newExplosion = Instantiate(explode,other.transform.position, other.transform.rotation);
        Destroy (newExplosion.gameObject, 2.5f);

        //this destroys the bricks when the ball hits them, and applies the explosion effect.

        gamemanager.UpdateScore (other.gameObject.GetComponent<brick>().points);
        gamemanager.UpdateNumberOfBricks ();

        // this is to keep track of the total bricks on screen, so the  game knows when to end. This also updates the points system.

        Destroy(other.gameObject);

          audio.Play();
          // this plays the sound effect when a brick is broken.
      }

    }
}
