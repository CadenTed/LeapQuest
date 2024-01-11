using System;
using TreeEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace DefaultNamespace
{
    public class PlayerMovement : MonoBehaviour
    {
        public Rigidbody2D playerRb;

        public Vector2 checkPos;

        public int speed = 2;
        public int force = 2;


        [SerializeField] private bool _isGrounded;
        private RaycastHit2D _hit;

        private void Start()
        {
            playerRb = GetComponent<Rigidbody2D>();
            _isGrounded = true;
        }

        private void Update()
        {
            Vector2 pos = transform.position;

            checkPos = pos;
            checkPos.y -= (transform.localScale.y / 2) + 0.01f;


            pos.x += speed * Time.deltaTime * Input.GetAxis("Horizontal");
            transform.position = pos;
            
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                playerRb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }

            
            if (pos.y < -10)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("EndlessMode");
            }

            _hit = Physics2D.Raycast(checkPos, -Vector2.up, 0.1f);

            

            if (_hit.collider == null)
            {
                _isGrounded = false;
            }
            else if (_hit.collider != null)
            {
                _isGrounded = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Goal"))
            {
                Debug.Log("GOAL!");
                SceneManager.LoadScene("EndlessMode");
            }

            if (other.gameObject.CompareTag("Collectible"))
            {
                Destroy(other.gameObject);
                Debug.Log("Plus 1 Point!");
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
        
            if (other.gameObject.CompareTag("Enemy"))
            {
                if (gameObject.transform.position.y > (other.gameObject.transform.position.y * 1.5f))
                {
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(gameObject);
                    SceneManager.LoadScene("EndlessMode");

                }
            }
        
            if (other.gameObject.CompareTag("Spikes"))
            {
                if (gameObject.transform.position.y > other.gameObject.transform.position.y * 1.5f)
                {
                    Destroy(gameObject);
                    SceneManager.LoadScene("EndlessMode");

                }
            }
        }
        
        
    }
}