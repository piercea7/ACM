using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseHitBoxManager : MonoBehaviour
{
	
	// Set these in the editor
	List<PolygonCollider2D> kickFrames = new List<PolygonCollider2D> ();
	List<PolygonCollider2D> standingFrames = new List<PolygonCollider2D> ();
	List<PolygonCollider2D> punchingFrames = new List<PolygonCollider2D> ();
	List<PolygonCollider2D> DodgeingFrames = new List<PolygonCollider2D> ();
	List<PolygonCollider2D> JumpingFrames = new List<PolygonCollider2D> ();
	List<PolygonCollider2D> KneelingFrames = new List<PolygonCollider2D> ();
	
	public GameObject HitBoxes;
	// Used for organization
	private PolygonCollider2D[] colliders;
	Quaternion rotat;
	
	// Collider on this game object
	private PolygonCollider2D localCollider;
	
	//Base Fighter
	BaseFighter fighter;
	
	public enum CharacterState
	{
		Kneeling,
		Standing,
		Kicking,
		Punching,
		Dodgeing,
		Jumping,
		Clear
	}
	
	void Start()
	{
		//loop through hitboxes and get hitboxes
		foreach (Transform trans in HitBoxes.transform)
		{
			switch (trans.gameObject.tag)
			{
			case "Fighter-Down":
				foreach (Transform poloy in trans.transform) {
					KneelingFrames.Add((PolygonCollider2D)poloy.GetComponent(typeof(PolygonCollider2D)));
				}
				break;
			case "Fighter-Dodge":
				foreach (Transform poloy in trans.transform) {
					DodgeingFrames.Add((PolygonCollider2D)poloy.GetComponent(typeof(PolygonCollider2D)));
				}
				break;
			case "Fighter-Jump":
				foreach (Transform poloy in trans.transform) {
					JumpingFrames.Add((PolygonCollider2D)poloy.GetComponent(typeof(PolygonCollider2D)));
				}
				break;
			case "Fighter-Weak":
				foreach (Transform poloy in trans.transform) {
					punchingFrames.Add((PolygonCollider2D)poloy.GetComponent(typeof(PolygonCollider2D)));
				}
				break;
			case "Fighter-Strong":
				foreach (Transform poloy in trans.transform) {
					kickFrames.Add((PolygonCollider2D)poloy.GetComponent(typeof(PolygonCollider2D)));
				}
				break;
			case "Fighter-Standing":
				foreach (Transform poloy in trans.transform) {
					standingFrames.Add((PolygonCollider2D)poloy.GetComponent(typeof(PolygonCollider2D)));
				}
				break;
			default:
				continue;
			}
		}
		
		// Set up an array so our script can more easily set up the hit boxes
		//colliders = new PolygonCollider2D[]{frame1, frame2, frame3};
		rotat = new Quaternion (0, 180, 0, 0);
		
		// Create a polygon collider
		localCollider = gameObject.AddComponent<PolygonCollider2D>();
		localCollider.pathCount = 0; // Clear auto-generated polygons
		
		// Base Fighter Stuff
		fighter = (BaseFighter)this.GetComponent (typeof(BaseFighter));
	}
	
	void Update()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			rotat = new Quaternion (0, 180, 0, 0);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			rotat = new Quaternion (0, 90, 0, 0);
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(fighter == null)
			return;
		
		fighter.HitMade (col);
	}
	
	//Use to set hit boxes frame by frame...
	//parm vals: use Kicking 1... to do Kicking polycollider 1
	//zero based
	public void setHitBox(string vals)
	{
		string[] values = vals.Split (new char[]{' '});
		int frameIndex = int.Parse (values [1]);
		switch (values[0]) 
		{
		case "Kicking":
			localCollider.SetPath(0, kickFrames[frameIndex].GetPath(0));
			return;
			
		case "Standing":
			localCollider.SetPath(0, standingFrames[frameIndex].GetPath(0));
			return;
			
		case "Kneeling":
			localCollider.SetPath(0, KneelingFrames[frameIndex].GetPath(0));
			return;
			
		case "Punching":
			localCollider.SetPath(0, punchingFrames[frameIndex].GetPath(0));
			return;
			
		case "Jumping":
			localCollider.SetPath(0, JumpingFrames[frameIndex].GetPath(0));
			return;
			
		case "Dodgeing":
			localCollider.SetPath(0, DodgeingFrames[frameIndex].GetPath(0));
			return;
			
		default:
			
			break;
		}
		
		localCollider.pathCount = 0;
	}
}



