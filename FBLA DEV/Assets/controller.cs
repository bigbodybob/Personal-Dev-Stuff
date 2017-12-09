using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour {
	public float maxSpeed;
	Animator anim;
	private bool isFacingRight=false;
	private float speed;
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D character = GetComponent<Rigidbody2D> ();
			
		float move = Input.GetAxis ("Horizontal");
		if (move > 0 &&!isFacingRight) {Flip ();
		}
		else if(move < 0 &&isFacingRight) {Flip ();
		}
		character.velocity = new Vector2 (move * maxSpeed, character.velocity.y);
		anim.SetFloat ("Speed",Mathf.Abs(move));

	}
	void Flip(){
		isFacingRight = !isFacingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
			transform.localScale=theScale;
		
	
	}
}
