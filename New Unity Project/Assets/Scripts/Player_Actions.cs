using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { walk, attack, interact }
public class Player_Actions : MonoBehaviour
{
    public PlayerState currentstate;
    Rigidbody2D rb;
    int health = 3;
    int score = 0;
    int gold = 0;
    int bombCount = 3;
    int kills = 0;
    int maxHealth = 3;
    float speed = 10;
    float attackCooldown = 0;
    float hitCooldown = 0;
    float bombCooldown = 0;
    float range = 1.5f;
    bool invincible = false;
    bool dead = false;
    Vector3 change;
    Vector2 direction;
    Animator animator;
    RaycastHit2D hit;
    GUIStyle style;
    public GameObject bomb;
    public LayerMask ignore;

    // Start is called before the first frame update
    void Start()
    {
        currentstate = PlayerState.walk;
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
            if(!dead)
            {
                if(Input.GetKeyDown("e"))
                {
                    bombCooldown = 1;
                    PlaceBomb();
                }
            }
        }
        else
            bombCooldown -= Time.deltaTime;

        if(attackCooldown <= 0)
        {
            if(!dead)
            {
                if(Input.GetKeyDown("space") && currentstate != PlayerState.attack)
                {
                    attackCooldown = .20f;
                    Attack();
                    StartCoroutine(AttackCo());
                }
            }
        }
        else
            attackCooldown -= Time.deltaTime;

        if (currentstate == PlayerState.walk)
        {
            UpdateAnimationAndMove();
        }
        
        if(hitCooldown <= 0)
            invincible = false;
        else
        {
            hitCooldown -= Time.smoothDeltaTime;
        }

    }
    
    private IEnumerator AttackCo()
    {
        animator.SetBool("attacking", true);
        currentstate = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.33f);
        currentstate = PlayerState.walk;
    }

    void Attack()
    {
        hit = Physics2D.CircleCast(transform.position, 2f, direction, range, ~ignore);
 
        if(hit.collider != null)
        {
            if(hit.collider.gameObject.tag == "Enemy")
            {
                Enemy_Actions e = hit.collider.gameObject.GetComponent<Enemy_Actions>();
                e.TakeDamage();
                e.AddKnockback(transform, 1000);
            }

            if(hit.collider.gameObject.tag == "Chest")
            {
                hit.collider.gameObject.GetComponent<Open_Chest>().Open();
            }
        }

        
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
        rb.MovePosition(transform.position + (change * speed * Time.fixedDeltaTime));
    }

    public void TakeDamage()
    {
        if(!invincible && !dead)
        {
            invincible = true;
            health--;
            hitCooldown = 1;
            if(health <= 0)
                Die();
        }
    }

    public void AddKnockback(Transform other, int force)
    {
        Vector2 hitDirection = (transform.position - other.transform.position).normalized;
        rb.AddForce(hitDirection * force);
    }

    public void AddScore(int amnt)
    {
        score += amnt;
        kills++;
    }

    void AddHealth()
    {
        if(health < maxHealth)
            health++;
    }

    void AddBomb()
    {
        bombCount++;
    }

    public void ChangeGold(int amount, bool change)
    {
        if (change == true)
        {
            gold += amount;
        }
        else
        {
            gold -= amount;
        }
    }

    void Die()
    {
        dead = true;
        Destroy(GetComponent<BoxCollider2D>());
        GameObject gameOver = GameObject.FindWithTag("Game Over");
        Game_Over g = gameOver.GetComponent<Game_Over>();
        g.GameOverText(score);
        g.ShowGameOver();
    }

    void PlaceBomb()
    {
        if(bombCount > 0)
        {
            Instantiate(bomb, transform.position, Quaternion.identity);  
            bombCount--;
        }
    }

    public void PickupItem(string name)
    {
        if(name == "Heart")
        {
            AddHealth();
        }

        if(name == "Bomb")
        {
            AddBomb();
        }

        if(name == "Coin")
        {
            ChangeGold(1, true);
        }
    }

    void OnGUI()
    {
        string txt = "Health: " + health.ToString() + "\n" 
                    + "Score: " + score.ToString() + "\n" 
                    + "Kills: " + kills.ToString()  + "\n" 
                    + "Gold: " + gold.ToString() + "\n"
                    + "Bombs: " + bombCount.ToString();
        GUI.TextField(new Rect(10, 10, 75, 40), txt, style);
    }
}
