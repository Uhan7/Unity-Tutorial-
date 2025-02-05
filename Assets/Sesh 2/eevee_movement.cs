using UnityEngine;

public class eevee_movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private AudioSource aSource;

    public AudioClip jumpSFX;

    public float speed;
    public float maxSpeed;
    public float jumpForce;
    public float friction;

    private bool grounded;

    public KeyCode moveLeftKey;
    public KeyCode moveRightKey;
    public KeyCode jumpKey;

    private bool movingLeft;
    private bool movingRight;
    private bool isJumping;

    // How do I check for inputs in Update()
    // But keep the physics stuff in FixedUpdate()

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        aSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(moveRightKey))
        {
            transform.localScale = new Vector3(1, 1, 1);
            movingRight = true;
        }
        else movingRight = false;

        if (Input.GetKey(moveLeftKey))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            movingLeft = true;
        }
        else movingLeft = false;

        if (Input.GetKeyDown(jumpKey))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX *= friction;

        if (isJumping && grounded)
        {
            isJumping = false;
            aSource.PlayOneShot(jumpSFX);
            rb.AddForceY(jumpForce);
        }

        if (movingLeft) rb.AddForceX(-speed);
        if (movingRight) rb.AddForceX(speed);

        if (rb.linearVelocityX > maxSpeed) rb.linearVelocityX = maxSpeed;
        if (rb.linearVelocityX < -maxSpeed) rb.linearVelocityX = -maxSpeed;
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        grounded = true;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        grounded = false;
    }
}
