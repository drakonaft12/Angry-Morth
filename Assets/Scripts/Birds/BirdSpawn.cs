using UnityEngine;


namespace Birds
{
    public class BirdSpawn : MonoBehaviour
    {
        [SerializeField] private Bird birdPrefab = null!;
        private TypeBirdBase[] type;

        private void Awake()
        {
            type = new TypeBirdBase[] { new StandartBird(), new FastBird(), new ThreeBird(this), new GigantBird() };
        }

        public Bird NextBird()
        {
            var bird = Instantiate(birdPrefab, transform.position, Quaternion.identity, transform);
            type[Random.Range(0, type.Length)].AddSetup(bird);
            return bird!;
        }

        public Bird NextBird(Bird _bird, Vector3 vector)
        {
            var bird = Instantiate(_bird, _bird.transform.position - vector, Quaternion.identity, transform);
            bird.IsCollision = true;
            bird.Rigidbody.isKinematic = false;
            bird.Rigidbody.velocity = _bird.Rigidbody.velocity - (Vector2)vector * _bird.Velosity*3;
            return bird!;
        }
    }
}