using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
    public float jumpPower = 1.0f;
    bool grounded = true;
    bool rightFace = true;
    bool upface = true;

	// Use this for initialization
	void Start ()
    {
	
	}

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetAxis("Horizontal") > 0 && !rightFace)
        {
            FlipPlayer();
        }
        else if (Input.GetAxis("Horizontal") < 0 && rightFace)
        {
            FlipPlayer();
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (rightFace)
            {
                transform.Rotate(0, 0, 90f);
            }
            else
            {
                transform.Rotate(0, 0, -90f);
            }
        }
        if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)))
        {
            if (rightFace)
            {
                transform.Rotate(0, 0, -90f);
            }
            else
            {
                transform.Rotate(0, 0, 90f);
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.AddForce(Vector3.up * jumpPower,ForceMode2D.Impulse);
                grounded = false;
            }
        }
    }
    void OnCollisionEnter2D (Collision2D hit)
    {
        grounded = true;
    }
    void FlipPlayer()
    {
        rightFace = !rightFace;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
