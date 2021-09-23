using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Actions : MonoBehaviour
{
    Transform target;
    Vector2 origin;

    int health = 3;
    float speed = 3;
    float aggroTimer = 0;
    float hitCooldown = 0;

    bool invincible = false;
    bool spotted = false;
    bool startTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        origin = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
 
        if(startTimer)
        {
            if(aggroTimer <= 0)
            {
                startTimer = false;
                spotted = false;
            }   
            else
                aggroTimer -= Time.deltaTime;
        }

        if(hitCooldown <= 0)
            invincible = false;
        else
        {
            invincible = true;
            hitCooldown -= Time.smoothDeltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            startTimer = false;
            spotted = true;
            aggroTimer = 5;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
            startTimer = true;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player_Actions>().TakeDamage();
            Vector2 direction = (other.transform.position - transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 500);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player_Actions>().TakeDamage();
            Vector2 direction = (other.transform.position - transform.position).normalized;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 500);
        }
    }

    void Move()
    {
        if(spotted)
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.smoothDeltaTime);
        else
            transform.position = Vector2.MoveTowards(transform.position, origin, speed * Time.smoothDeltaTime);

    }

    public void TakeDamage()
    {
        if(!invincible)
        {
            health--;
            hitCooldown = 1;
            if(health <= 0)
                Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
        GameObject p = GameObject.FindWithTag("Player");
        p.GetComponent<Player_Actions>().AddScore(100);
    }
}
