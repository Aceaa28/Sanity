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
	public Animator anim;
	bool grounded = false;
	public Transform groundCheck;
	public Transform attackPoint;
	public float attackRange = .05f;
	public LayerMask enemyLayers;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public GameObject[] enemy;

	//variable for how high player jumps//
	public float jumpForce = 1.5f;

	public Rigidbody2D rb { get; set; }

	bool dead = false;
	bool attack = false;

	float horizontal;
	float vertical;
	
	// Player attack variables
	CircleCollider2D circleCol;
	bool circleColActive = true;

	bool holdBat;

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

		//animation for bat//
		if (Input.GetKeyDown (KeyCode.Z)) 
		{
			holdBat = anim.GetBool("HoldBat");

			if(!holdBat)
			{
				anim.SetBool("HoldBat", true);
				holdBat = true;
			}
			
			else if(holdBat)
			{
				anim.SetBool("HoldBat", false);
				holdBat = false;
			}
		}

		if(holdBat && ((horizontal > 0) || (horizontal < 0) ))
		{
			
			anim.SetFloat ("BatRun", 0.2f);
		}
		
		else if(holdBat && horizontal == 0)
		{
			anim.SetFloat ("BatRun", 0);
		}

		
	}

	void OnDrawGizmosSelected()
	{
		if (attackPoint == null)
		return;

		Gizmos.DrawWireSphere(attackPoint.position, attackRange);
	}

	//movement//
	void FixedUpdate ()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		if (!dead && !attack)
		{
			anim.SetFloat ("vSpeed", rb.velocity.y);
			anim.SetFloat ("Speed", Mathf.Abs (horizontal));
			rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
		}
		if (horizontal > 0 && !facingRight && !dead && !attack) 
		{
			Flip (horizontal);
		}

		else if (horizontal < 0 && facingRight && !dead && !attack)
		{
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

			//Detect enemies in range of attack
			Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

			//Damage them
			foreach(Collider2D enemy in hitEnemies)
			{
				Enemy enemyScript = enemy.GetComponent<Enemy>();
				Debug.Log(enemyScript.health);
				enemyScript.health -= 1;
				Debug.Log("we hit " + enemy.name);
			}

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

	
}
