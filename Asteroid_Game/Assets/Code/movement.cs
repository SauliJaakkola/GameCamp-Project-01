using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

	public Rigidbody2D rb;
	float moveHorizontal = 0f;
	public float turn;
	public float speed;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		moveHorizontal -= Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = transform.up * moveVertical;
		transform.eulerAngles = new Vector3 (0f, 0f, moveHorizontal * turn);
		rb.AddForce (movement * speed);
	}
}
