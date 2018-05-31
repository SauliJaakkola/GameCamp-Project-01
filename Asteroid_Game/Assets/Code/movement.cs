using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour {

	public Rigidbody2D rb;
	float moveHorizontal = 0f;
	public float turn;
	public float speed;
    public float fuel;
    public float timer;
    public Text fuelText;

    public Animator anim;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
        fuel = 10f;
        fuelText.text = "Fuel: " + fuel.ToString();
        InvokeRepeating("FuelDown", timer, timer);

        anim = GetComponent<Animator>();
    }

	void Update()
	{
		moveHorizontal -= Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isMoving", true);
        } else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isMoving", false);
        }

		Vector2 movement = transform.up * moveVertical;
		transform.eulerAngles = new Vector3 (0f, 0f, moveHorizontal * turn);
		rb.AddForce (movement * speed);
	}

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "asteroid")
        {
            Destroy(gameObject);
            fuelText.text = "YOU LOSE!";
        }

        if (hit.gameObject.tag == "fuel")
        {
            Destroy(hit.gameObject);
            fuel += 5f;
            fuelText.text = "Fuel: " + fuel.ToString();
        }

    }

    private void FuelDown()
    {
        fuel--;
        fuelText.text = "Fuel: " + fuel.ToString();
    }
}
