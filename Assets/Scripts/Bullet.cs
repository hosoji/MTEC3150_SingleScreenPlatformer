using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]public float speed = 10;
    [HideInInspector] public Vector2 direction;
    private Rigidbody2D rb;

    private SpriteRenderer sr;
    [HideInInspector] public Color col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();

        sr.color = col;

        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = direction * speed * Time.deltaTime;
    }




}
