using UnityEngine;
using System.Collections;

public class BaseFighter : MonoBehaviour
{
	/* Stats for hero */
	[Header("Stats")]
	public float Health = 100;                              // health all characters will have 1000 hp
	public int JumpCount = 1;                             // Number of Times you can jump
	public float Agility = 5.0f;                          // handles the jumps and kneeling
	public float Speed = 5.0f;                            // the speed of the player
	public float Defense = 1.0f;                          // Reduces the damage by this percent
	public int[] AttackPower = new int[7];
	public const int NumberOfCombos = 5;                  // this is more of a reminder of how much combos everyone has.
	public PlayerSize playerSize = PlayerSize.Normal;     // the size of the player (large, Small, Normal)
	public PlayerState StateOfPlayer = PlayerState.Standing;      // State of the player (I.E Jumping, Dodgeing ect..)
	[HideInInspector]
	public int CurrentSpecialUsed = 0;                    //This is used for damage (When you combo set this to combo number). I.E Combo1 = 1
	/******************/
	
	
	/*Other Character*/
	public BaseFighter otherPlayer;
	
	/* Key Controls */
	[Header("Key Controls")]
	public KeyCode Up = KeyCode.UpArrow;
	public KeyCode Down = KeyCode.DownArrow;
	public KeyCode Right = KeyCode.RightArrow;
	public KeyCode Left = KeyCode.LeftArrow;
	public KeyCode Weak = KeyCode.Z;
	public KeyCode Strong = KeyCode.X;
	[HideInInspector]
	public KeyCode[] Controls;  //Array of controls *treat as read-only*
	/*****************/
	
	[Header("Character Info")]
	public Animator anim = new Animator();
	public Rigidbody2D rigid = new Rigidbody2D();
	public bool IsFirstPlayer = true;
	
	bool canMove = true;
	int jumps = 0;
	float timer = 0f, timeBetweenAttacks = 0.2f;
	void Start()
	{
		if (!IsFirstPlayer)
		{
			Up = KeyCode.W;
			Down = KeyCode.S;
			Right = KeyCode.D;
			Left = KeyCode.A;
			Weak = KeyCode.Q;
			Strong = KeyCode.E;
		}
		Controls = new KeyCode[]{Up,Down,Right,Left,Weak,Strong};
		
		StartVars ();
		//Attack Power - use unity edior
		//0 weak attack
		//1 power attack
		//2 combo 1
		//3 combo 2
		//4 combo 3
		//5 combo 4
		//6 combo 5
	}

	void Update()
	{
		timer += Time.deltaTime;
		UpdateFighter ();
	}
	

	//Used For HitBoxes
	public virtual void HitMade(Collision2D col) 
	{
		//Reset the jump counter.. hit either floor or player
		jumps = 0;
		//Dont care if player is touching the floor
		if(col.gameObject.tag == "Floor"){
		//turn the fuck around
			return;
		}
			
		if(timer >= timeBetweenAttacks)
		{
			timer = 0f;
			//This is the default way of dealing damage to other player
			if(StateOfPlayer == PlayerState.Strong || StateOfPlayer == PlayerState.Weak || StateOfPlayer == PlayerState.Special)
			{
				BaseFighter otherPlayer =  (BaseFighter)col.gameObject.GetComponent(typeof(BaseFighter));
				
				if(StateOfPlayer == PlayerState.Weak)
					otherPlayer.DealDamageToSelf(AttackPower[0]);
				if(StateOfPlayer == PlayerState.Strong)
					otherPlayer.DealDamageToSelf(AttackPower[1]);
				if(StateOfPlayer == PlayerState.Special)
					otherPlayer.DealDamageToSelf(AttackPower[1 + CurrentSpecialUsed]);
			}
		}
	}
	
	//This is how damage is dealt to player
	public virtual void DealDamageToSelf(float attackPower)
	{
	
	}
	
	// Use this for initialization
	public virtual void StartVars () 
	{

	}

	// Update is called once per frame
	public virtual void UpdateFighter () {
		HandleMovement(GetMovement());
	}
	
	public KeyCode GetMovement()
	{
		if(Input.GetKeyDown(Up))
			return Up;
		else if(Input.GetKeyDown(Down))
			return Down;
		else if (Input.GetKeyDown(Left))
		   return Left;
		else if (Input.GetKeyDown(Right))
			return Right;
		else if (Input.GetKeyDown(Weak))
			return Weak;
		else if (Input.GetKeyDown(Strong))
			return Strong;

		return KeyCode.At;
	}
	
	public void HandleMovement(KeyCode inputKey)
	{
		if(Input.GetKeyUp(Up) || Input.GetKeyUp(Down) || Input.GetKeyUp(Left) || 
		Input.GetKeyUp(Right) || Input.GetKeyUp(Strong) || Input.GetKeyUp(Weak))
		{
			canMove = true;
			anim.SetInteger ("Move", 0);
			StateOfPlayer = PlayerState.Standing;
		}
			
		if(canMove)
		{
			if(inputKey == Up && (jumps < JumpCount))
			{
				anim.SetInteger ("Move", 1);
				rigid.velocity = new Vector2(rigid.velocity.x, Agility*2);
				StateOfPlayer = PlayerState.Jumping;
				canMove = false;
				jumps++;
			}
			
			if(inputKey == Down)
			{
				anim.SetInteger ("Move", 4);
				rigid.velocity = new Vector2(rigid.velocity.x, -Agility);
				StateOfPlayer = PlayerState.Kneeling;
				canMove = false;
			}
			
			if(inputKey == Left)
			{
				anim.SetInteger ("Move", 2);
				transform.rotation = new Quaternion(0,180,0,0);
				rigid.velocity = new Vector2(-Speed, rigid.velocity.y);
				StateOfPlayer = PlayerState.Dodgeing;
				canMove = false;
			}

			if(inputKey == Right)
			{
				anim.SetInteger ("Move", 5);
				transform.rotation = new Quaternion(0,0,0,0);
				rigid.velocity = new Vector2(Speed, rigid.velocity.y);
				StateOfPlayer = PlayerState.Dodgeing;
				canMove = false;
			}
			
			if(inputKey == Weak)
			{
				anim.SetInteger ("Move", 6);
				StateOfPlayer = PlayerState.Weak;
			}
			
			if(inputKey == Strong)
			{
				anim.SetInteger ("Move", 3);
				StateOfPlayer = PlayerState.Strong;
			}
		}
	}
}

public class KeyCombo
{
	public string[] buttons;
	private int currentIndex = 0; //moves along the array as buttons are pressed
	
	public float allowedTimeBetweenButtons = 0.3f; //tweak as needed
	private float timeLastButtonPressed;
	
	public KeyCode Up = KeyCode.UpArrow;
	public KeyCode Down = KeyCode.DownArrow;
	public KeyCode Right = KeyCode.RightArrow;
	public KeyCode Left = KeyCode.LeftArrow;
	public KeyCode Weak = KeyCode.Z;
	public KeyCode Strong = KeyCode.X;
	
	public KeyCombo()
	{
		buttons = new string[]{"right"};
	}
	
	public KeyCombo(string[] b, KeyCode[] keyCodes)
	{
		buttons = b;
		
		Up = keyCodes[0];
		Down = keyCodes[1];
		Right = keyCodes[2];
		Left = keyCodes[3];
		Weak = keyCodes[4];
		Strong = keyCodes[5];
	}
	
	//usage: call this once a frame. when the combo has been completed, it will return true
	public bool Check()
	{
		if (Time.time > timeLastButtonPressed + allowedTimeBetweenButtons) currentIndex = 0;
		{
			if (currentIndex < buttons.Length)
			{
				if ((buttons[currentIndex] == "down" && Input.GetKeyDown(Down)) ||
				    (buttons[currentIndex] == "up" && Input.GetKeyDown(Up)) ||
				    (buttons[currentIndex] == "left" && Input.GetKeyDown(Left)) ||
				    (buttons[currentIndex] == "right" && Input.GetKeyDown(Right)) ||
				    (buttons[currentIndex] == "weak" && Input.GetKeyDown(Weak)) ||
				    (buttons[currentIndex] == "strong" && Input.GetKeyDown(Strong)) ||
				    (buttons[currentIndex] != "down" && buttons[currentIndex] != "up" && buttons[currentIndex] != "left" && 
				     buttons[currentIndex] != "right" && buttons[currentIndex] != "weak" && buttons[currentIndex] != "strong" && Input.GetButtonDown(buttons[currentIndex])))
				{
					timeLastButtonPressed = Time.time;
					currentIndex++;
				}
				
				if (currentIndex >= buttons.Length)
				{
					currentIndex = 0;
					return true;
				}
				else return false;
			}
		}
		
		return false;
	}
}

public enum PlayerSize
{
	XL,
	Large,
	Small,
	Normal 
}

public enum PlayerState
{
	Kneeling,
	Standing,
	Strong,
	Weak,
	Dodgeing,
	Jumping,
	Special
}

