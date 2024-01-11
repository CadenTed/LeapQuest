using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class Spawner : MonoBehaviour
    {
        public GameObject enemy;
        public GameObject spike;
        public GameObject goal;
        public GameObject ground;
        public GameObject collectible;

        private void Start()
        {
            Vector2[] groundTilePoints = new Vector2[50];
            Vector2[] spikeTilePoints = new Vector2[5];
            Vector2[] enemyTilePoints = new Vector2[3];
            Vector2[] collectiblePoints = new Vector2[5];

            Instantiate(goal);

            Instantiate(ground);
            
            for (int index = 0; index < groundTilePoints.Length; index++)
            {
                Vector2 point = groundTilePoints[index];

                point.x = Random.Range(-8, 42);
                point.y = Random.Range(0, 0);

                groundTilePoints[index] = point;
            }
            
            for (int index = 0; index < spikeTilePoints.Length; index++)
            {
                Vector2 point = spikeTilePoints[index];

                point.x = Random.Range(0, 33);
                point.y = 0.79f;

                spikeTilePoints[index] = point;
            }
            
            for (int index = 0; index < enemyTilePoints.Length; index++)
            {
                Vector2 point = enemyTilePoints[index];

                point.x = Random.Range(0, 33);
                point.y = 1.4f;

                enemyTilePoints[index] = point;
            }

            for (int index = 0; index < collectiblePoints.Length; index++)
            {
                Vector2 point = collectiblePoints[index];

                point.x = Random.Range(0, 42);
                point.y = Random.Range(1.5f, 3.5f);

                collectiblePoints[index] = point;
            }
            
            foreach (Vector2 point in groundTilePoints)
            {
                ground.transform.position = point;
                ground.transform.Rotate(Vector2.zero, Random.Range(0, 360));
                

                Instantiate(ground);
            }
            
            foreach (Vector2 point in spikeTilePoints)
            {
                spike.transform.position = point;
                spike.transform.Rotate(Vector3.zero, Random.Range(0, 360));

                Instantiate(spike);
            }

            foreach (Vector2 point in enemyTilePoints)
            {
                enemy.transform.position = point;
                enemy.transform.Rotate(Vector2.zero, Random.Range(0, 360));

                Instantiate(enemy);
            }

            foreach (Vector2 point in collectiblePoints)
            {
                collectible.transform.position = point;
                collectible.transform.Rotate(Vector2.zero, Random.Range(0, 360));

                Instantiate(collectible);
            }
        }

        private void Update()
        {
            
        }
    }
}