using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

    private BoxCollider2D bc2d;                 //This stores a reference to the collider attached to the GameObject.
    private float horizontalLength;             //A float to store the x-axis length of the collider2D attached to the GameObject.

    private void Awake()
    {
        //Get and store a reference to the collider2D attached to GameObject.
        bc2d = this.GetComponent<BoxCollider2D>();
        //Store the size of the collider along the x axis (its length in units).
        horizontalLength = bc2d.size.x;
    }
	
	// Update is called once per frame
	void Update () {
        //Check if the difference along the x axis between the main Camera and the position of the GameObject this is attached to is greater than horizontalLength.
        //Remember that this GameObject is scrolling backwards along the x-axis, with the main character sitting at x-axis equal to 0
        if (transform.position.x < -horizontalLength)
        {
            //If true, this means this object is no longer visible and we can safely move it forward to be re-used.
            RepositionBackground();
        }
    }

    /// <summary>
    /// Moves the object this script is attached to right in order to create our looping background effect.
    /// </summary>
    private void RepositionBackground()
    {
        //This is how far to the right we will move our background object, in this case, twice its length.
        //This will position it directly to the right of the currently visible background object.
        Vector2 offset = new Vector2(horizontalLength * 2f, 0);
        //Move this object from it's position offscreen, behind the player, to the new position off-camera in front of the player.
        transform.position = (Vector2)transform.position + offset;
    }
}
