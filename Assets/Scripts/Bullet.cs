using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public Vector2 direction;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * speed * Time.deltaTime;
    }


}
