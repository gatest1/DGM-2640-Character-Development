using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float MoveSpeed;
	public float TurnSpeed;
	public float GravitySpeed;
	public float JumpSpeed;
	private CharacterController MyCC;
	private Vector3 tempPos;
	private Vector3 tempRot;
	/* put this on a Capsule to test, if you have animated models, they'll be a child to this
	  capsule, in which case you'd turn of the Mesh Renderer for this object.
	  Make sure the Capsule has a Character Controller Component added onto it.
	  Adjust values for Gravity, movespeed, turnspeed and jumpspeed to fit your needs in the inspector-
	  All of these values are affected by the Scale you're working in, so I left them blank. 
	  Jumping for this script will look jittery, but it's fine for the 
	  testing that you'll be doing at this point.*/
	void Start () {
			MyCC = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			tempPos.y = JumpSpeed*Time.deltaTime;
			MyCC.Move (tempPos);
		}
		tempPos.y = -GravitySpeed;
		tempRot.y = TurnSpeed * Input.GetAxis ("Horizontal");
		transform.Translate(Vector3.forward*MoveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
		MyCC.Move (tempPos*Time.deltaTime);
		MyCC.transform.Rotate (tempRot);

	}
}