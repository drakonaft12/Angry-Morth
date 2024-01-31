using UnityEngine;
using UnityEngine.Events;


namespace Birds
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bird : MonoBehaviour
    {
        private new Rigidbody2D _rigidbody = null!;
        [SerializeField] private float _velosity = 2;
        private bool _isCollision = false;
        public UnityEvent<Bird> WorkInput; 
        public Rigidbody2D Rigidbody { get => _rigidbody; }
        public float Velosity { get => _velosity; set => _velosity = value; }
        public bool IsCollision { get => _isCollision; set => _isCollision = value; }

        private void OnCollisionEnter2D(Collision2D _collision)
        {
            if (!_rigidbody.isKinematic)
            {
                _isCollision = true;
            }
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>()!;
            _rigidbody.isKinematic = true;
        }

        private void Update()
        {
            if(!_rigidbody.isKinematic)
            WorkInput?.Invoke(this);
        }

        public void Launch(Vector2 direction)
        {
            _rigidbody.isKinematic = false;
            _rigidbody.AddForce(direction * _rigidbody.mass * _rigidbody.gravityScale * _velosity, ForceMode2D.Impulse);
        }
    }
}