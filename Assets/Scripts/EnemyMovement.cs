using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DefaultNamespace
{
    public class EnemyMovement : MonoBehaviour
    {
        public float speed = 5f;
        public Vector2 negXCheck, posXCheck;
        private RaycastHit2D negXHit, posXHit;

        private void Update()
        {
            negXCheck = transform.position;
            negXCheck.y -= transform.localScale.y / 2;
            negXCheck.x -= transform.localScale.x / 2;
            

            posXCheck = transform.position;
            posXCheck.y -= transform.localScale.y / 2;
            posXCheck.x += transform.localScale.x / 2;
            
            negXHit = Physics2D.Raycast(negXCheck, Vector3.down, 0.5f);

            posXHit = Physics2D.Raycast(posXCheck, Vector3.down, 0.5f);
            
            if (negXHit.collider == null) 
            {
                speed = -speed;
            }

            if (posXHit.collider == null)
            {
                speed = -speed;
            }

            Debug.DrawRay(negXCheck, Vector3.down * 0.5f, Color.red);
            Debug.DrawRay(posXCheck, Vector3.down * 0.5f, Color.blue);

            
            Vector2 pos = transform.position;

            pos.x += speed * Time.deltaTime;
            transform.position = pos;

            if (pos.y < -10)
            {
                Destroy(gameObject);
            }

            
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Spikes"))
            {
                speed = -speed;
            }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                speed = -speed;
            }
        }
        
    }
}