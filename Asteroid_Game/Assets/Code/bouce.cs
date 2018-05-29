using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouce : MonoBehaviour {

    public Rigidbody2D rb;
    public float speedUp;
    public float speedSide;
    private RaycastHit2D hit;

    void Start()
    {
        Invoke("Spawn", 0.1f);
    }
    void Spawn()
    {
        rb = GetComponent<Rigidbody2D>();
        speedUp = Random.Range(-50f, 50f);
        speedSide = Random.Range(-50f, 50f);
        rb.AddForce(new Vector2(speedUp, speedSide));
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "asteroid")
        {
            speedUp = Random.Range(-20f, 20f);
            speedSide = Random.Range(-20f, 20f);
            rb.AddForce(new Vector2(speedUp, speedSide));
        }

        if (hit.gameObject.tag == "wall")
        {
            speedUp = Random.Range(-50f, 50f);
            speedSide = Random.Range(-50f, 50f);
            rb.AddForce(new Vector2(speedUp, speedSide));
        }

        if (hit.gameObject.tag == "fuel")
        {
            Destroy(hit.gameObject);
        }
    }
}
