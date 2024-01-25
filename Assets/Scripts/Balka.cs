using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Balka : MonoBehaviour
{
    [SerializeField] float hp = 5;

    private Rigidbody2D rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        hp *= rigidbody.mass / rigidbody.gravityScale * 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Destroed"))
        hp -= collision.rigidbody.velocity.magnitude;
    }

    private void Update()
    {
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
