using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public float gameHeight = 4.75f;
	public float paddleHeight = 3.5f;
	public float paddleSpeed = 5f;
	public int playerOneScore = 0;
	public int playerTwoScore = 0;
	public GameObject playerOne;
	public GameObject playerTwo;
	public GameObject playerOneGoal;
	public GameObject playerTwoGoal;
	public GameObject UI;
	private GameObject canvas;
	public GameObject ballPrefab;
	private BallMovement ball;

	// Use this for initialization
	void Start () {
		PlayerMovement playerOneScript = playerOne.GetComponent<PlayerMovement>();
		PlayerMovement playerTwoScript = playerTwo.GetComponent<PlayerMovement>();
		playerOneScript.paddleHeight = paddleHeight;
		playerTwoScript.paddleHeight = paddleHeight;
		playerOneScript.gameHeight = gameHeight;
		playerTwoScript.gameHeight = gameHeight;
		playerOneScript.speed = paddleSpeed;
		playerTwoScript.speed = paddleSpeed;
		playerOneScript.Init();
		playerTwoScript.Init();
		canvas = Instantiate (UI, new Vector3(0, 0, 0), Quaternion.identity);
		ball = Instantiate (ballPrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<BallMovement>();
		ball.gameManager = this;
		StartCoroutine(ballSpawnTime());
	}
	public void Score (GameObject goal) {
		if (goal == playerOneGoal) {
			playerOneScore += 1;
			canvas.transform.GetChild(1).GetComponent<Text>().text = (playerOneScore < 10 ? "0":"")+playerOneScore;
		}
		if (goal == playerTwoGoal) {
			playerTwoScore += 1;
			canvas.transform.GetChild(2).GetComponent<Text>().text = (playerTwoScore < 10 ? "0":"")+playerTwoScore;
		}
		Destroy(ball.transform.gameObject);
		ball = Instantiate (ballPrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<BallMovement>();
		ball.gameManager = this;
		StartCoroutine(ballSpawnTime());
	}
	IEnumerator ballSpawnTime() {
        yield return new WaitForSeconds(1);
		ball.Init();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
