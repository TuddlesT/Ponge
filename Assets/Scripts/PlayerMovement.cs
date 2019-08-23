using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed;
	public float gameHeight;
	public string axisName;
	[HideInInspector]public float paddleHeight;
	// Use this for initialization
	public void Init () {
		transform.localScale = new Vector3(transform.localScale.x, paddleHeight, transform.localScale.z);
	}
	
	// Update is called once per frame
	void Update () {
		float clamp = gameHeight - transform.localScale.y / 2;
		transform.Translate(Vector3.up * Time.deltaTime * Input.GetAxis(axisName) * speed);
		transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -clamp, clamp ), transform.position.z);
		
	}
}
