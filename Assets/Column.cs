using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Poogle
{
    public class Column : MonoBehaviour
    {

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Drifting>() != null)
            {
                //If Poogle hits the trigger collider in between the water columns then
                //tell the game control that Poogle scored.
                GameManager.Singleton.CharacterScored();
            }
        }
    }
}

