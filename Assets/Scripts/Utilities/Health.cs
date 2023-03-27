using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth {  get; private set; }
    private Animator anim;
    [HideInInspector] public bool dead;

    [Header("iFrames")]
    [SerializeField] private float invulnerablityDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;

    [Header("Components")]
    [SerializeField]private Behaviour[] components;

    private void Awake()
    {
        currentHealth = startingHealth;
        //anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if(currentHealth > 0)
        {
            //anim.SetTrigger("Hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {
            if (!dead)
            {


                foreach(Behaviour component in components)
                {
                    component.enabled = false;
                }
                Destroy(gameObject, 8);

                dead = true;
            }
            
        }
    }

    /*private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(1);
        }
    }*/

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(invulnerablityDuration / (numberOfFlashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(invulnerablityDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
