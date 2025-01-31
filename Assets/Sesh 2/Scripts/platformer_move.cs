using System.Collections;
using UnityEngine;

public class platformer_move : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource aSource;

    public float speed;
    public float maxSpeed;
    public float jumpForce;

    public float friction;

    public bool movingRight;
    public bool movingLeft;
    private bool grounded;
    public bool isJumping;

    public KeyCode moveLeftKey;
    public KeyCode moveRightKey;
    public KeyCode jumpKey;

    public AudioClip jumpSFX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        aSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(moveRightKey))
        {
            movingRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else movingRight = false;

        if (Input.GetKey(moveLeftKey))
        {
            movingLeft = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else movingLeft = false;

        if (Input.GetKeyDown(jumpKey))
        {
            isJumping = true;
        }

        SetAnims();
    }

    void FixedUpdate()
    {
        if (movingRight) rb.AddForceX(speed);
        if (movingLeft) rb.AddForceX(-speed);
        if (isJumping && grounded)
        {
            isJumping = false;
            aSource.PlayOneShot(jumpSFX);
            rb.AddForceY(jumpForce);
        }

        Friction();
        LimitSpeed();
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        grounded = true;
        anim.SetBool("grounded", grounded);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        grounded = false;
        anim.SetBool("grounded", grounded);
    }

    void SetAnims()
    {
        anim.SetFloat("speed", Mathf.Abs(rb.linearVelocityX));
    }

    void Friction()
    {
        rb.linearVelocityX *= friction;
    }

    void LimitSpeed()
    {
        if (rb.linearVelocityX > maxSpeed) rb.linearVelocityX = maxSpeed;
        if (rb.linearVelocityX < -maxSpeed) rb.linearVelocityX = -maxSpeed;
    }
}
