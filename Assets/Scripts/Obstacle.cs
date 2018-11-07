using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
        {
            //If the character hits the trigger collider in between the obstacles then
            //tell the game control that the character scored.
            GameControl.instance.CharacterScored();
        }
    }
}
