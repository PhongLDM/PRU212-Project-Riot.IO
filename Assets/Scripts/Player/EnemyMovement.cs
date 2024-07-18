using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;
    private GameObject player;

    Vector2 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        lastPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = player.GetComponent<PlayerStats>().speed;

        // Get the player's current position
        Vector2 currentPosition = rb.position;
        Vector2 positionDelta = currentPosition - lastPosition;

        // Set animator parameters based on position change
        animator.SetFloat("Horizontal", positionDelta.x);
        animator.SetFloat("Vertical", positionDelta.y);
        animator.SetFloat("Speed", positionDelta.sqrMagnitude);

        // Flip sprite based on movement direction
        if (positionDelta.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (positionDelta.x > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Update last position
        lastPosition = currentPosition;
    }

    private void FixedUpdate()
    {
        // Movement
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movement.x == 0 || movement.y == 0)
        {
            rb.velocity = movement * moveSpeed;
        }
        else
        {
            rb.velocity = movement * (moveSpeed / Mathf.Sqrt(2));
        }
    }

    static float squareRoot(int number)
    {
        float temp;
        float sr = number / 2;

        do
        {
            temp = sr;
            sr = (temp + (number / temp)) / 2;
        } while ((temp - sr) != 0);
        return sr;
    }
}
