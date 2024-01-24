using UnityEngine;


namespace Birds
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bird : MonoBehaviour
    {
        private new Rigidbody2D rigidbody = null!;


        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>()!;
            rigidbody.isKinematic = true;
        }


        public void Launch(Vector2 direction)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce(direction*50000, ForceMode2D.Impulse);
        }
    }
}