using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Poogle
{
    public class ObstaclePool : MonoBehaviour
    {

        public GameObject obstaclePrefab;
        public int poolSize = 8;                                         //How many obstacles to keep on standby.
        public float spawnRate = 3f;                                    //How quickly obstacles spawn. One every spawnRate seconds.
        public float heightMin = -3f;                                   //Minimum y value of the obstacle position.
        public float heightMax = 1.5f;                                  //Maximum y value of the obstacle position.

        private GameObject[] obstacles;                                 //Collection of pooled obstacles.
        private int currentObstacleIndex;                               //Index of the current obstacle in the collection.

        private Vector2 objectPoolPosition = new Vector2(-15, -25);     //A holding position for our unused obstacles offscreen.
        private float spawnXPosition = 15f;
        private float timeSinceLastSpawned;

        // Use this for initialization
        void Start()
        {
            timeSinceLastSpawned = 0f;

            obstacles = new GameObject[poolSize];
            //Loop through the collection... 
            for (int i = 0; i < poolSize; i++)
            {
                //...and create the individual obstacles.
                obstacles[i] = (GameObject)Instantiate(obstaclePrefab, objectPoolPosition, Quaternion.identity);
            }

        }

        // Update is called once per frame
        void Update()
        {
            timeSinceLastSpawned += Time.deltaTime;
            //This spawns obstacles as long as the game is not over and it is time to spawn a new obstacle.
            if (!GameManager.Singleton.gameOver && timeSinceLastSpawned >= spawnRate)
            {
                timeSinceLastSpawned = 0f;

                //Set a random y position for the obstacle
                float spawnYPosition = Random.Range(heightMin, heightMax);
                //...then set the current obstacle to that position.
                obstacles[currentObstacleIndex].transform.position = new Vector2(spawnXPosition, spawnYPosition);

                //Increase the value of currentObstacleIndex. If the new size is too big, set it back to zero
                currentObstacleIndex++;

                if (currentObstacleIndex >= poolSize)
                {
                    currentObstacleIndex = 0;
                }
            }
        }
    }
}

