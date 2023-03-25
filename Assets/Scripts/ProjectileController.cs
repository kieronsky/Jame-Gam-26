using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 20f;
    
    Rigidbody2D rb;
    //int attack = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        rb.velocity = speed * transform.right;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
