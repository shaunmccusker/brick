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


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
        audio = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
      if (gamemanager.gameOver){
         return;

      }
      if(inPlay == false){
         transform.position = paddle.position;
      }
      if(Input.GetButtonDown("Jump") && inPlay == false)  {
        inPlay = true;
        rb.AddForce(Vector2.up * speed);
      }

    }


    void OnTriggerEnter2D(Collider2D other){
    if (other.CompareTag("Bottom")){
      Debug.Log("L");
      rb.velocity = Vector2.zero;
      inPlay = false;
      gamemanager.UpdateLives(-1);
        }

    }

    void OnCollisionEnter2D(Collision2D other){
      if(other.transform.CompareTag("brick")){
        Transform newExplosion = Instantiate(explode,other.transform.position, other.transform.rotation);
        Destroy (newExplosion.gameObject, 2.5f);

        gamemanager.UpdateScore (other.gameObject.GetComponent<brick>().points);
        gamemanager.UpdateNumberOfBricks ();

        Destroy(other.gameObject);

          audio.Play();
      }

    }
}
