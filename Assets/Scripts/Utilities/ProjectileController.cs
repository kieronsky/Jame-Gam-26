using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float cardSpeed;
    private float direction;
    private bool hit;
    private BoxCollider2D boxCollider;
    //private Animator anim;
    private float lifetime;
    
    Rigidbody2D rb;
    //int attack = 1;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb.velocity = cardSpeed * transform.right;

    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = cardSpeed * Time.deltaTime * direction;
        //transform.Translate(movementSpeed, 0, 0);
        lifetime += Time.deltaTime;
        if (lifetime > 0.25) Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        //anim.SetTrigger("Hit");
        if (collision.tag == "Enemy")
            collision.GetComponent<Health>().TakeDamage(1);
            Destroy(this.gameObject);
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactive()
    {
        gameObject.SetActive(false);
    }
}
