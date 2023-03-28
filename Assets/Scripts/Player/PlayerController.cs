using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Moving")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator anim;
    AudioSource audioData;
    [Header("Audio")]
    [SerializeField] AudioClip footSteps;
    [SerializeField] AudioClip shoot;

    [Header("Shooting")]
    public ProjectileController projectileController;
    [SerializeField] private Transform launchOffset;
    [SerializeField] private float attackCooldown;

    [HideInInspector] public bool isFacingLeft;
    [HideInInspector] public Vector2 facingLeft;
    [HideInInspector] public bool spawnFacingLeft;
    
    private float cooldownTimer = Mathf.Infinity;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();

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
        rb.velocity = (new Vector2(movement.x, rb.velocity.y));
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (Mathf.Abs(horizontalInput) > 0)
            audioData.PlayOneShot(footSteps);
        else audioData.Stop();

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
            anim.SetBool("Jumping", true);

        }
        Shooting();
        cooldownTimer += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("Jumping", false);
        }
        
    }

    void Shooting()
    {
        if (Input.GetButtonDown("Fire1") && cooldownTimer > attackCooldown)
        {
            Instantiate(projectileController, launchOffset.position, transform.rotation);
            cooldownTimer = 0;
            audioData.PlayOneShot(shoot);
            //anim.SetTrigger("Attack");


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
