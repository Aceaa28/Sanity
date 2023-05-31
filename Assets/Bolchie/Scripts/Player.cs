using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//Basic Player Script//
//controls: 
//A, D, Left, Right to move
//Left Alt to attack
//Space to jump
//Z is to see dead animation

public class Player : MonoBehaviour
{
    //variable for how fast player runs//
	private float speed = 10f;

	private bool facingRight = true;
	private Animator anim;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public GameObject enemy;

	//variable for how high player jumps//
	public float jumpForce;

	public Rigidbody2D rb { get; set; }

	bool dead = false;
	bool attack = false;

	float horizontal;
	float vertical;
	
	CircleCollider2D circleCol;
	bool circleColActive = true;

	[SerializeField] private Animator normalAnimator;
	[SerializeField] private Animator batModeAnimator;
	[SerializeField] private SpriteRenderer playerSpriteRenderer;
	[SerializeField] private Sprite normalSprite;
	[SerializeField] private Sprite batModeSprite;

private bool isBatMode = false;

	void Start () 
	{
		GetComponent<Rigidbody2D> ().freezeRotation = true;
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponentInChildren<Animator> ();
		circleCol = GetComponent<CircleCollider2D>();

	}

	void Update()
	{
		HandleInput ();

		if (circleColActive == false)
		{
			circleCol.isTrigger = true;
			//circleColActive = true;
		}

		//dead animation for bat//
		if (Input.GetKeyDown (KeyCode.Z)) 
		{
			// Toggle the bat mode
			isBatMode = !isBatMode;

			 // Swap sprites based on bat mode
			playerSpriteRenderer.sprite = isBatMode ? batModeSprite : normalSprite;

			// Activate/deactivate animators based on bat mode
			normalAnimator.enabled = !isBatMode;
			batModeAnimator.enabled = isBatMode;
		}

		// Check if the player is in bat mode
		if (isBatMode)
		{
			// Handle bat mode movement
			BatModeMovement();
		}
		else
		{
			// Handle normal movement
			FixedUpdate();
			HandleInput();
		}	
	}

	//movement//
	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		Debug.Log("Grounded: " + grounded);
		anim.SetBool ("Ground", grounded);

		horizontal = Input.GetAxis("Horizontal");
		 vertical = Input.GetAxis("Vertical");
		if (!dead && !attack)
		{
			anim.SetFloat ("vSpeed", rb.velocity.y);
			anim.SetFloat ("Speed", Mathf.Abs (horizontal));
			rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
		}
		if (horizontal > 0 && !facingRight && !dead && !attack) {
			Flip (horizontal);
		}

		else if (horizontal < 0 && facingRight && !dead && !attack){
			Flip (horizontal);
		}
	}

	//attacking and jumping//
	private void HandleInput()
	{
		if (Input.GetKeyDown (KeyCode.LeftAlt) && !dead) 
		{
			attack = true;
			anim.SetBool ("Attack", true);
			anim.SetFloat ("Speed", 0);

		}
		if (Input.GetKeyUp(KeyCode.LeftAlt))
			{
			attack = false;
			anim.SetBool ("Attack", false);
			}

		if (grounded && vertical > 0 && !dead)
		{
			anim.SetBool ("Ground", false);
			grounded = false;
			Debug.Log("Jumped: " + grounded);
			rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
		}
	}
		
	private void Flip (float horizontal)
	{
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Platform"))
		{
			circleColActive = false;
		}

	}

	void BatModeMovement()
	{

	}
}
