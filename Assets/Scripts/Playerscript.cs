using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour {

    public float jumpPower = 10.0f;
    Rigidbody2D myRigidbody;
    bool isGrounded = false;
    float posX = 0.0f;
    bool isGameOver = false;
    ChallengeController mychallengeController;
    GameController myGameController;

    //Soundplayer
    AudioSource myAudioPlayer;
    public AudioClip jumpSound;
    public AudioClip pointSound;
    public AudioClip deathSound;

	// Use this for initialization
	void Start () {
        myRigidbody = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
        mychallengeController = GameObject.FindObjectOfType<ChallengeController>();
        myGameController = GameObject.FindObjectOfType<GameController>();
        myAudioPlayer = GameObject.FindObjectOfType<AudioSource>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.Space) && isGrounded && !isGameOver)
        {
            myRigidbody.AddForce(Vector3.up * (jumpPower * myRigidbody.mass * myRigidbody.gravityScale * 20.0f));
            myAudioPlayer.PlayOneShot(jumpSound);
            isGrounded = false;
        }
        // If Player hits side of objects
        if (transform.position.x < posX && !isGameOver)
        {
            GameOver();
        }
	}

   

    void GameOver()
    {
        isGameOver = true;
        myAudioPlayer.PlayOneShot(deathSound);
        mychallengeController.GameOver();
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.collider.tag == "Ground" )
        {
            isGrounded = true;
        }
        if (other.collider.tag == "Enemy")
        {
            GameOver();
        }
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Point")
        {
            myGameController.IncrementScore();
            myAudioPlayer.PlayOneShot(pointSound);
            Destroy(other.gameObject);

        }
    }
}
