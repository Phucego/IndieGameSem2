using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 5f; // Time in seconds before the arrow is destroyed
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime); // Destroy the arrow after 'lifeTime' seconds

        // Set the velocity of the arrow in the direction it is facing
        rb.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle what happens when the arrow hits something
        Destroy(gameObject);
    }
}