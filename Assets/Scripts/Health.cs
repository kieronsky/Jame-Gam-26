using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth {  get; private set; }
    private Animator anim;

    private void Awake()
    {
        currentHealth = startingHealth;
        //anim = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if(currentHealth > 0)
        {
            //anim.SetTrigger("Hurt");
        }
        else
        {
            //Player
            //anim.SetTrigger("Die");

            //Enemy
            if(GetComponentInParent<EnemyPatrol>() != null) 
            GetComponentInParent<EnemyPatrol>().enabled = false;
            
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
}
