using UnityEngine;
using UnityEngine.Events;


namespace Birds
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bird : MonoBehaviour
    {
        private new Rigidbody2D rigidbody = null!;
        [SerializeField] private float velosity = 2;
        private bool isCollision = false;
        public UnityEvent<Bird> WorkInput; 
        public Rigidbody2D Rigidbody { get => rigidbody; }
        public float Velosity { get => velosity; set => velosity = value; }
        public bool IsCollision { get => isCollision; set => isCollision = value; }

        private void OnCollisionEnter2D(Collision2D _collision)
        {
            if (!rigidbody.isKinematic)
            {
                isCollision = true;
            }
        }

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>()!;
            rigidbody.isKinematic = true;
        }

        private void Update()
        {
            if(!rigidbody.isKinematic)
            WorkInput?.Invoke(this);
        }

        public void Launch(Vector2 direction)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce(direction * rigidbody.mass * rigidbody.gravityScale * velosity, ForceMode2D.Impulse);
        }
    }
}