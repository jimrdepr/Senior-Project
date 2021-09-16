using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Actions : MonoBehaviour
{
    Rigidbody2D rb;
    int health = 3;
    int score = 0;
    float speed = 50;
    float attackCooldown = 0;
    float hitCooldown = 0;
    float range = 2;
    bool invincible = false;
    Vector3 change;
    Vector2 direction;
    Animator animator;
    RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        
        UpdateAnimationAndMove();
        if(Input.GetKey("w"))
            direction = Vector2.up;
        if(Input.GetKey("a"))
            direction = Vector2.left;
        if(Input.GetKey("s"))
            direction = Vector2.down;
        if(Input.GetKey("d"))
            direction = Vector2.right;
        if(attackCooldown <= 0)
        {
            if(Input.GetKeyDown("space"))
            {
                attackCooldown = 1;
                Attack();
            }
        }
        else
            attackCooldown -= Time.deltaTime;
        
        if(hitCooldown <= 0)
            invincible = false;
        else
        {
            hitCooldown -= Time.smoothDeltaTime;
            invincible = true;
        }

    }

    void Attack()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        hit = Physics2D.Raycast(transform.position, direction, range, layerMask);

        if(hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "Enemy")
            {
                print(hit.collider.gameObject.name);
                hit.collider.gameObject.SendMessage("TakeDamage");
            }
        }
        else
            print("missed");
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            Move();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
            animator.SetBool("moving", false);

    }

    void Move()
    {
        rb.MovePosition(transform.position + (change * speed * Time.smoothDeltaTime));
    }

    void TakeDamage()
    {
        if(!invincible)
        {
            health--;
            hitCooldown = 2;
            print(health);
            if(health <= 0)
                Die();
        }
    }

    void Die()
    {
        
    }

    void PlaceBomb()
    {
        
    }
}
