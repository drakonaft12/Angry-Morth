using UnityEngine;


namespace Birds
{
    public class BirdSpawn : MonoBehaviour
    {
        [SerializeField] private Bird birdPrefab = null!;
        private TypeBirdBase[] type;

        private void Awake()
        {
            new CreateBoom2D();
            type = new TypeBirdBase[] { new BoomBird(), new FastBird(), new StandartBird(), new GigantBird(), new ThreeBird(this)};
            
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                if (Time.timeScale == 1) Time.timeScale = 0.2f;
                else Time.timeScale = 1;
            }
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