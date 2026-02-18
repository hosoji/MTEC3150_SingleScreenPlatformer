using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float jumpSpeed;
    private float xMove;
    private float xVelocity;

    private Rigidbody2D rb;

    private bool jumpFlag = false;

    public LayerMask ground;

    public GameObject meleeAttack;

    private float facingDirection;

    private float attackOffset = 0.8f;

    public float meleeDuration = 0.25f;
    private float timeElapsedSinceMelee = 0;

    private bool meleeTriggered = false;

    public GameObject bulletPrefab;

    public float bulletSpeed = 200;
    private float defaultBulletSpeed; 
    public Color bulletColor = Color.yellow;
    private Color defaultBulletColor;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingDirection = 1;
        defaultBulletSpeed = bulletSpeed;
        defaultBulletColor = bulletColor;

    }

    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpFlag = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            MeleeAttack();
        }


        if (Input.GetMouseButtonDown(1))
        {
            RangedAttack();
        }

        if (xMove != 0)
        {
            facingDirection = xMove;
        }

        if (meleeTriggered)
        {
            if (timeElapsedSinceMelee < meleeDuration)
            {
                timeElapsedSinceMelee += Time.deltaTime;
            }
            else
            {
                meleeAttack.SetActive(false);
                timeElapsedSinceMelee = 0;
                meleeTriggered = false;
            }
        }

        WhenOnPlatform();

        //Debug.Log("Player on platform is :" + IsOnPlatform());
        //Debug.Log(IsGrounded());
        //transform.Translate(xMove * movementSpeed * Time.deltaTime, 0, 0); 
    }

    private void FixedUpdate()
    {
        xVelocity = xMove * movementSpeed * Time.deltaTime;
        rb.linearVelocity = new Vector3(xVelocity, rb.linearVelocity.y, 0);

        if (jumpFlag)
        {
            rb.linearVelocityY = jumpSpeed;
            jumpFlag = false;

        }
    }


    private void MeleeAttack()
    {
        meleeTriggered = true;
        meleeAttack.SetActive(true);
        meleeAttack.transform.localPosition = new Vector3(attackOffset * facingDirection, meleeAttack.transform.localPosition.y, 0);
    }

    private void RangedAttack()
    {
        Vector3 pos = new Vector3(transform.position.x + (attackOffset * facingDirection), transform.position.y, 0);
        GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
        Bullet bScript = bullet.GetComponent<Bullet>();

        bScript.direction = new Vector2(facingDirection, 0);
        bScript.col = bulletColor;
        bScript.speed = bulletSpeed;
        

    }

    private bool IsGrounded()
    {
        float radius = GetComponent<Collider2D>().bounds.extents.x;
        float dist = GetComponent<Collider2D>().bounds.extents.y;

        return Physics2D.CircleCast(transform.position, radius, Vector2.down, dist,ground);
    }

    private void WhenOnPlatform()
    {
        if (IsGrounded()) {
            float radius = GetComponent<Collider2D>().bounds.extents.x;
            float dist = GetComponent<Collider2D>().bounds.extents.y;

            RaycastHit2D hit;
            hit = Physics2D.CircleCast(transform.position, radius, Vector2.down, dist, ground);

            if (hit.transform.gameObject.CompareTag("Platform"))
            {
                transform.SetParent(hit.transform);
            }
            else
            {
                transform.SetParent(null);
            }
        }
        else
        {
            transform.SetParent(null);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PowerUp>() != null)
        {
            collision.GetComponent<PowerUp>().ApplyEffect();

        }
    }


    public void ApplyBulletChanges(float speed, Color color)
    {
        bulletSpeed = speed;
        bulletColor = color;

    }

    public void ResetBullet()
    {
        ApplyBulletChanges(defaultBulletSpeed, defaultBulletColor);
    }
}
