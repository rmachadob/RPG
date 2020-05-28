using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ctrl K + crtl f indent
public class PlayerController : MonoBehaviour {
    //RB = Rigid Body
    public Rigidbody2D theRB;
    public float moveSpeed;
    //Animator component added automatically when I created it
    public Animator myAnim;

    //static: there can be only one version of this
    public static PlayerController instance;

    public string areaTransitionName;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    // Use this for initialization
    void Start () {

        if (instance == null)//only empty when the game starts running
        {
            //avoiding multiple players when chaging areas
            //the instance value has to be equal to this script
            instance = this;
        }
        else
        {//if he is not the only one, destroy the second one imediately
           
            Destroy(gameObject);
            
        }
        //Whenever you load a scene, do not destroy whatever is between these brackets
        //By default the gameObject is whatever game object this script is attached to 
        //I put it on the start function cause I only want that to happen once when the object is created
        DontDestroyOnLoad(gameObject);

	}
	
	// Update is called once per frame
	void Update () {
        //velocity is a Vector 2 type (2 values, Y and x)
        //GetAxisRaw to get a more precise value instead of only GetAxis(got a weird acceleration to it)
        //The axis I wanna use is the Horizontal (the x value = Horizontal
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

        //Setting a Float value. I created moveX and moveY on the Blend Tree
        //I wanna set the moveX value to be the velocity of the Rigid Body on the x axis
        //The names moveX and moveY need to be the same from the ones I declared as a parameter on the Animator for the player
        myAnim.SetFloat("moveX", theRB.velocity.x);

        //The same for the Y axis
        myAnim.SetFloat("moveY", theRB.velocity.y);

        //setting the lastMove values 
        //if an input at any moment is the whole number, the person is pushing in the direction
        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            //we know the value that the player is inputing, so we store it as last value
            myAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));

        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
            Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y),
            transform.position.z);
    }

    public void SetBounds(Vector3 bottomLeft, Vector3 topRight){

        bottomLeftLimit = bottomLeft + new Vector3(0.5f, 1f, 0f);
        topRightLimit = topRight + new Vector3(-0.5f, -1f, 0f);

    }

}
