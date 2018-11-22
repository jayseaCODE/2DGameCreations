using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drifting : MonoBehaviour {

    public float force = 200f;                     //Force of the drift (upward and downward)

    private bool isDead = false;            //Has the character touch the streams?
    private Animator anim;                  //Reference to the Animator component.
    private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the bird.

    private float screenHeight;

    // Use this for initialization
    void Start () {
        anim = this.GetComponent<Animator>();
        rb2d = this.GetComponent<Rigidbody2D>();
        screenHeight = Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
		//Don't allow control if character is dead
        if (!isDead)
        {
            //Check if we are running either in the Unity editor or in a standalone build.
#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER

            //Look for input to trigger upward drift
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //...tell the animator about it and then...
                anim.SetTrigger("WaddleUp");
                //...zero out the character's current y velocity before...
                rb2d.velocity = Vector2.zero;
                //  new Vector2(rb2d.velocity.x, 0);
                //..giving the character some upward force.
                rb2d.AddForce(new Vector2(0, force));
            }
            //Look for input to trigger downward drift
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //...tell the animator about it and then...
                anim.SetTrigger("WaddleDown");
                //...zero out the character's current y velocity before...
                rb2d.velocity = Vector2.zero;
                //  new Vector2(rb2d.velocity.x, 0);
                //..giving the character some downward force.
                rb2d.AddForce(new Vector2(0, -force));
            }
#endif
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Zero out the character's velocity
        rb2d.velocity = Vector2.zero;
        // If the character collides with something set it to dead...
        isDead = true;
        //...tell the Animator about it...
        anim.SetTrigger("Die");
        //...and tell the game control about it.
        GameControl.instance.CharacterDied();
    }

    public void SendCharacterDriftingUp ()
    {
        if (!isDead)
        {
            //...tell the animator about it and then...
            anim.SetTrigger("WaddleUp");
            //...zero out the character's current y velocity before...
            rb2d.velocity = Vector2.zero;
            //  new Vector2(rb2d.velocity.x, 0);
            //..giving the character some upward force.
            rb2d.AddForce(new Vector2(0, force));
        }
    }
    public void SendCharacterDriftingDown()
    {
        if (!isDead)
        {
            //...tell the animator about it and then...
            anim.SetTrigger("WaddleDown");
            //...zero out the character's current y velocity before...
            rb2d.velocity = Vector2.zero;
            //  new Vector2(rb2d.velocity.x, 0);
            //..giving the character some downward force.
            rb2d.AddForce(new Vector2(0, -force));
        }
    }
}
