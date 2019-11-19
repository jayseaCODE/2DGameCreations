﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Poogle
{
    public class ScrollingObject : MonoBehaviour
    {

        private Rigidbody2D rb2d;

        // Use this for initialization
        void Start()
        {
            //Get and store a reference to the Rigidbody2D attached to this GameObject.
            rb2d = this.GetComponent<Rigidbody2D>();
            //Start the object moving.
            rb2d.velocity = new Vector2(GameManager.Singleton.scrollSpeed, 0);
        }

        // Update is called once per frame
        void Update()
        {
            // If the game is over, stop scrolling.
            if (GameManager.Singleton.gameOver == true)
            {
                rb2d.velocity = Vector2.zero;
            }
        }
    }
}