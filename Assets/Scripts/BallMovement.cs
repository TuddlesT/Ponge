using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	public GameManager gameManager;
	private Rigidbody2D body;
	public float speedY = 300;
	public float initialY = 150;
	public int startDirection = -1;
	public float initialX = 600;

	public AudioSource audioData;

	// Use this for initialization
	public void Init () {
		initialX = initialX * startDirection;
		body = gameObject.GetComponent<Rigidbody2D>();
		body.AddForce(new Vector2(initialX, Random.Range(-initialY, initialY)));
		audioData = GetComponent<AudioSource>();
	}
	public void startDirectionChange (int winner) {
		if (winner == 1) {
			startDirection = 1;
		}
		else if (winner == 2) {
			startDirection = -1;
		}
	}
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			float difference = collision.gameObject.transform.position.y - transform.position.y;
			body.AddForce(new Vector2(0, -difference * speedY / collision.gameObject.transform.localScale.y));
			audioData.Play();
		}
	}
	void OnTriggerEnter2D(Collider2D collider) {
		gameManager.Score(collider.gameObject);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
