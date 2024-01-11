using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DestroyObject : MonoBehaviour
    {
        private Vector2 _checkPosOne;
        private Vector2 _checkPosTwo;
        private Vector2 _checkPosThree;

        private Vector2 _scale;

        private Vector2 _pos;
        
        private RaycastHit2D _hitOne, _hitTwo, _hitThree;


        private void Start()
        {
            _scale = transform.localScale;

        }

        private void Update()
        {
            _checkPosOne = transform.position;
            _checkPosOne.y -= _scale.y / 2;
            _checkPosOne.x -= _scale.x / 2;
            
            _checkPosTwo = transform.position;
            _checkPosTwo.y -= _scale.y / 2;

            _checkPosThree = transform.position;
            _checkPosThree.y -= _scale.y / 2;
            _checkPosThree.x += _scale.x / 2;

            _hitOne = Physics2D.Raycast(_checkPosOne, UnityEngine.Vector2.down);
            _hitTwo = Physics2D.Raycast(_checkPosTwo, UnityEngine.Vector2.down);
            _hitThree = Physics2D.Raycast(_checkPosThree, UnityEngine.Vector2.down);

            if (_hitOne.collider == null || _hitTwo.collider == null || _hitThree.collider == null)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Goal"))
            {
                Destroy(gameObject);
            }
        }
    }
}