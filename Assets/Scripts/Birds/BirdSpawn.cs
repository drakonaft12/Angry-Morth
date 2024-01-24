using UnityEngine;


namespace Birds
{
    public class BirdSpawn : MonoBehaviour
    {
        [SerializeField] private Bird birdPrefab = null!;


        public Bird NextBird()
        {
            return Instantiate(birdPrefab, transform.position, Quaternion.identity, transform)!;
        }
    }
}