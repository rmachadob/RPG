using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //RB = Rigid Body
    public Rigidbody2D theRB;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //velocity is a Vector 2 type (2 values, Y and x)
        //GetAxisRaw to get a more precise value instead of only GetAxis(got a weird acceleration to it)
        //The axis I wanna use is the Horizontal (the x value = Horizontal
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
	}
}
