using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyMovement : MonoBehaviour {

	public float speed = 5.0f;
	public Animator anim = new Animator();
	public Rigidbody2D rigid = new Rigidbody2D();
	public PlayerState state = PlayerState.Standing;

	public bool canMove = true, canJump = true, firstPlayer = true;

	// Use this for initialization
	void Start () 
	{

	}
	void movementForFirst()
	{
		#region Movement
		if(rigid.position.y < -.50f)
			canJump = true;
		if (Input.GetKeyDown (KeyCode.UpArrow) && canMove && canJump)
		{
			anim.SetInteger ("Move", 1);
			rigid.velocity = new Vector2(rigid.velocity.x, speed*2);
			canMove = false;
			canJump = false;
		}
		else if (Input.GetKeyUp (KeyCode.UpArrow) && !canMove)
		{
			anim.SetInteger ("Move", 0);
			canMove = true;
		}
		
		if (Input.GetKeyDown (KeyCode.LeftArrow) && canMove) 
		{
			anim.SetInteger ("Move", 2);
			transform.rotation = new Quaternion(0,180,0,0);
			rigid.velocity = new Vector2(-speed, rigid.velocity.y);
			canMove = false;
		}
		else if (Input.GetKeyUp (KeyCode.LeftArrow) && !canMove)
		{
			anim.SetInteger ("Move", 0);
			canMove = true;
		}
		
		if (Input.GetKeyDown (KeyCode.RightArrow) && canMove) 
		{
			anim.SetInteger ("Move", 5);
			transform.rotation = new Quaternion(0,0,0,0);
			rigid.velocity = new Vector2(speed, rigid.velocity.y);
			canMove = false;
		}
		if (Input.GetKeyUp (KeyCode.RightArrow) && !canMove)
		{
			anim.SetInteger ("Move", 0);
			canMove = true;
		}
		
		if (Input.GetKeyDown (KeyCode.PageUp) && canMove) 
		{
			anim.SetInteger ("Move", 3);
			canMove = false;
		}
		else if (Input.GetKeyUp (KeyCode.PageUp) && !canMove)
		{
			anim.SetInteger ("Move", 0);
			canMove = true;
		}
		
		if (Input.GetKeyDown (KeyCode.PageDown) && canMove) 
		{
			anim.SetInteger ("Move", 6);
			canMove = false;
		}
		else if (Input.GetKeyUp (KeyCode.PageDown) && !canMove)
		{
			anim.SetInteger ("Move", 0);
			canMove = true;
		}
		
		if (Input.GetKeyDown (KeyCode.DownArrow) && canMove) 
		{
			anim.SetInteger ("Move", 4);
			rigid.velocity = new Vector2(rigid.velocity.x, -speed);
			canMove = false;
		}
		if (Input.GetKeyUp (KeyCode.DownArrow) && !canMove)
		{
			anim.SetInteger ("Move", 0);
			canMove = true;
		}
		#endregion
	}
	void movementForSecond()
	{
		#region Movement
		if(rigid.position.y < -.50f)
			canJump = true;
		if (Input.GetKeyDown (KeyCode.W) && canMove && canJump)
		{
			anim.SetInteger ("Move", 1);
			rigid.velocity = new Vector2(rigid.velocity.x, speed*2);
			canMove = false;
			canJump = false;
		}
		else if (Input.GetKeyUp (KeyCode.W) && !canMove)
		{
			anim.SetInteger ("Move", 0);
			canMove = true;
		}
		
		if (Input.GetKeyDown (KeyCode.A) && canMove) 
		{
			anim.SetInteger ("Move", 2);
			transform.rotation = new Quaternion(0,180,0,0);
			rigid.velocity = new Vector2(-speed, rigid.velocity.y);
			canMove = false;
		}
		else if (Input.GetKeyUp (KeyCode.A) && !canMove)
		{
			anim.SetInteger ("Move", 0);
			canMove = true;
		}
		
		if (Input.GetKeyDown (KeyCode.D) && canMove) 
		{
			anim.SetInteger ("Move", 5);
			transform.rotation = new Quaternion(0,0,0,0);
			rigid.velocity = new Vector2(speed, rigid.velocity.y);
			canMove = false;
		}
		if (Input.GetKeyUp (KeyCode.D) && !canMove)
		{
			anim.SetInteger ("Move", 0);
			canMove = true;
		}
		
		if (Input.GetKeyDown (KeyCode.Q) && canMove) 
		{
			anim.SetInteger ("Move", 3);
			canMove = false;
		}
		else if (Input.GetKeyUp (KeyCode.Q) && !canMove)
		{
			anim.SetInteger ("Move", 0);
			canMove = true;
		}
		
		if (Input.GetKeyDown (KeyCode.E) && canMove) 
		{
			anim.SetInteger ("Move", 6);
			canMove = false;
		}
		else if (Input.GetKeyUp (KeyCode.E) && !canMove)
		{
			anim.SetInteger ("Move", 0);
			canMove = true;
		}
		
		if (Input.GetKeyDown (KeyCode.S) && canMove) 
		{
			anim.SetInteger ("Move", 4);
			rigid.velocity = new Vector2(rigid.velocity.x, -speed);
			canMove = false;
		}
		if (Input.GetKeyUp (KeyCode.S) && !canMove)
		{
			anim.SetInteger ("Move", 0);
			canMove = true;
		}
		#endregion
	}
	// Update is called once per frame
	void Update () {
		if (firstPlayer)
						movementForFirst ();
				else
						movementForSecond ();
	}
}

