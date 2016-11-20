using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
    public float jumpPower = 1.0f;
    bool grounded = true;
    bool rightFace = true;
	// Use this for initialization
	void Start ()
    {
	
	}

	// Update is called once per frame
	void Update ()
    {
        //Vector2 x = Input.GetAxis("Horizontal") * transform.right * Time.deltaTime * speed;
        //transform.Translate(x);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position += new Vector3(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log(grounded.ToString());
            if (grounded)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.AddForce(Vector3.up * jumpPower,ForceMode2D.Impulse);
                grounded = false;
            }
        }
        if (Input.GetAxis("Horizontal") > 0 && !rightFace)
        {
            FlipPlayer();
        }
        else if (Input.GetAxis("Horizontal") < 0 && rightFace)
        {
            FlipPlayer();
        }
    }
    void OnCollisionEnter2D (Collision2D hit)
    {
        grounded = true;
        Debug.Log("on ground");
    }
    void FlipPlayer()
    {
        rightFace = !rightFace;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
