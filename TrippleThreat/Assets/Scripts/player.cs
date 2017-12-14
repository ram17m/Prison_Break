using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour {
	private float playerLife;
	private Animator animator;
	private Rigidbody2D Player;
	public float jumpheight;
	public float speed;
	bool grounded = true;
	bool facingRight = true;
	public Rigidbody2D bullet;


	// Use this for initialization

	void Start () {
		//instantiate
		animator = GetComponent<Animator> ();
		Player = GetComponent<Rigidbody2D> ();
		playerLife = 3;
		bullet = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
				move();
		if (Input.GetKeyDown(KeyCode.Space)) {//when space key is down, fire method is called
			fire ();
		}

	}


	void move(){
		
		if (Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.RightArrow)) {//left or right arrow defines which direction character is moved
			transform.Translate (new Vector3 (Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));//movement
			animator.SetInteger ("state", 1);//setting integer to 1 to call for animation
		} 

		transform.Translate (new Vector3 (Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));


	if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) {
		animator.SetInteger ("state", 0);
	}
	}
	void OnCollisionEnter2D(Collision2D collision){//when collisioni is detected, this is called.
		if (collision.rigidbody.tag == "enemy") {
			Debug.Log ("dead");
			respawn ();
			if (playerLife == 0) {
				Destroy (gameObject);
				Debug.Log ("Gameover");
			}
		}

	}

	void respawn(){
		playerLife -=1f;
		transform.position = Vector3.zero;
	
	}
	void FixedUpdate() {
		
		//Horizontal Control
		float move = Input.GetAxis ("Horizontal");
		//move left or right (using Addforce)
		if (grounded) {
			Player.AddForce(Vector2.right * move * Time.deltaTime);//adding force to give a body motion to the right direction
		}
		if (Mathf.Abs (Player.velocity.x) > speed) {
			Player.velocity = new Vector2 (speed * move, Player.velocity.y);
		}
		if (move > 0 && !facingRight) {
			Flip ();
		} else if (move < 0 && facingRight) {
			Flip ();

		}
		Debug.Log ("state 1 in action");
		animator.SetInteger ("state", 1);

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Player.velocity = new Vector2 (0, jumpheight);
			Debug.Log ("state 2 in action");
			animator.SetInteger ("state", 2);
		} else if (Input.GetKeyUp (KeyCode.UpArrow)) {
			Player.velocity = new Vector2 (0, -jumpheight);
		}

	}

	//Check to see if grounded or not
	void OnTriggerEnter2D() {
		grounded = true;
	}

	void OnTriggerExit2D ()
	{
		grounded = false;
	}
	void Flip ()
	{

		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

	}
	 
	void OnBecameInvisible ()
	{
		respawn ();
	}

	void fire(){
		bullet= Instantiate(bullet, bullet.position, transform.rotation);//duplicates bullet from its position
		bullet.velocity = transform.forward * speed;//velocity assigned.
	}
}











