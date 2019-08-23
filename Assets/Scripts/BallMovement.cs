using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
	public GameManager gameManager;
	private Rigidbody2D body;
	[Range(0, 500)]public float initialX = 300;
	[Range(0, 500)]public float speedY = 100;
	public float initialY = 150;
	// Use this for initialization
	public void Init () {
		body = gameObject.GetComponent<Rigidbody2D>();
		body.AddForce(new Vector2(initialX, Random.Range(-initialY, initialY)));
	}
	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			float difference = collision.gameObject.transform.position.y - transform.position.y;
			body.AddForce(new Vector2(0, -difference * speedY / collision.gameObject.transform.localScale.y));
		}
	}
	void OnTriggerEnter2D(Collider2D collider) {
		gameManager.Score(collider.gameObject);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
