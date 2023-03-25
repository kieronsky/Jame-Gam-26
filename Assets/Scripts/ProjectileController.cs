using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;
    private PlayerController playerController;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //transform.position += transform.forward * Time.deltaTime * speed;
        rb.AddForce(transform.forward * speed);
        //nie wiem czemu wystrzeliwuje w dol a nie do przodu. do poprawki..
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
