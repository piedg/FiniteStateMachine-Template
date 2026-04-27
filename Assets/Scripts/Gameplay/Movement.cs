using UnityEngine;

namespace Gameplay
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;
    
        private float _moveX;
        private Rigidbody2D _rigidBody;

        private void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Move();
        }
    
        public void SetCurrentDirection(float currentDirection)
        {
            _moveX = currentDirection;
        }
    
        private void Move()
        {
            Vector2 movement = new(_moveX * moveSpeed, _rigidBody.linearVelocity.y);
            _rigidBody.linearVelocity = movement;
        }
    }
}