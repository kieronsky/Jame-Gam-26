using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator anim;
    public ProjectileController projectileController;
    public Transform launchOffset;
    public bool isFacingLeft;
    [HideInInspector] public Vector2 facingLeft;
    [HideInInspector] public bool spawnFacingLeft;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
        if (spawnFacingLeft)
        {
            transform.localScale = facingLeft;
            isFacingLeft = true;
        }
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f) * moveSpeed;
        rb.velocity = new Vector2(movement.x, rb.velocity.y);
        if (horizontalInput > 0 && isFacingLeft)
        {
            isFacingLeft = false;
            Flip();
        }
        if (horizontalInput < 0 && !isFacingLeft)
        {
            isFacingLeft = true;
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
        Shooting();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectileController, launchOffset.position, transform.rotation);
        }
    }
    public void Flip()
    {
        if (isFacingLeft)
        {
            
            transform.Rotate(0f, 180f, 0f);
        }
        if (!isFacingLeft)
        {
            
            transform.Rotate(0f,-180f, 0f);
        }
    }
}
