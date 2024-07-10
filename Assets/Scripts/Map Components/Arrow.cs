using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 5f; 
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime); 

        // Set the velocity of the arrow in the direction it is facing (forward direction)
        rb.velocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle what happens when the arrow hits something
        Destroy(gameObject);
    }
}