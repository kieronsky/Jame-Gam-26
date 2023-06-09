using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Patrol points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement paramters")]
    //[SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;
    //[SerializeField] private float idleDuration;
    private float idleTimer;
    //[Header("Animation")]
    //[SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            { 
                MoveInDirection(-1); 
            }
            else
            { 
                DirectionChange(); 
            }

            
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else

            {
                DirectionChange();
            }
               
            
        }
    }

    private void DirectionChange()
    {
        //anim.SetBool("Moving", false);
        idleTimer += Time.deltaTime;
        if (idleTimer > Random.Range(0.6f, 2.5f))
            movingLeft = !movingLeft;
    }

    private void MoveInDirection(int direction)
    {
        idleTimer = 0;
        //anim.SetBool("Moving", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * Random.Range(1f, 4f), enemy.position.y, enemy.position.z);
    }
}
