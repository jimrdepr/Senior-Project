using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Actions : MonoBehaviour
{
    Rigidbody2D rb;
    int health = 3;
    int score = 0;
    int bombCount = 3;
    int kills = 0;
    float speed = 50;
    float attackCooldown = 0;
    float hitCooldown = 0;
    float bombCooldown = 0;
    float range = 2;
    bool invincible = false;
    bool dead = false;
    Vector3 change;
    Vector2 direction;
    Animator animator;
    RaycastHit2D hit;
    GUIStyle style;
    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        style = new GUIStyle();
        style.fontSize = 20;
        style.normal.textColor = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        if(!dead)
        {
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
        }
        
        UpdateAnimationAndMove();
        if(Input.GetKey("w"))
            direction = Vector2.up;
        if(Input.GetKey("a"))
            direction = Vector2.left;
        if(Input.GetKey("s"))
            direction = Vector2.down;
        if(Input.GetKey("d"))
            direction = Vector2.right;

        if(bombCooldown <= 0)
        {
            if(Input.GetKeyDown("e"))
            {
                bombCooldown = 1;
                PlaceBomb();
            }
        }
        else
            bombCooldown -= Time.deltaTime;
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
            invincible = true;
            hitCooldown -= Time.smoothDeltaTime;
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
                Enemy_Actions e = hit.collider.gameObject.GetComponent<Enemy_Actions>();
                e.TakeDamage();
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

    public void TakeDamage()
    {
        if(!invincible && !dead)
        {
            health--;
            hitCooldown = 2;
            if(health <= 0)
                Die();
        }
    }

    public void AddScore(int amnt)
    {
        score += amnt;
        kills++;
    }


    void Die()
    {
        dead = true;
    }

    void PlaceBomb()
    {
        if(bombCount > 0)
        {
            Instantiate(bomb, transform.position, Quaternion.identity);  
            bombCount--;
        }
    }

    void OnGUI()
    {
        string txt = "Health: " + health.ToString() + "\n" 
                    + "Score: " + score.ToString() + "\n" 
                    + "Kills: " + kills.ToString()  + "\n" 
                    + "Bombs: " + bombCount.ToString();
        GUI.TextField(new Rect(10, 10, 75, 40), txt, style);
    }
}
