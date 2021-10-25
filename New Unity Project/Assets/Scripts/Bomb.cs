using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float timer;
    float addHitbox;
    Rigidbody2D rb;
    CircleCollider2D circle;
    public LayerMask ignore;
    bool added;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        added = false;
        addHitbox = timer - 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer <= addHitbox)
        {
            if(!added)
            {
                rb = gameObject.AddComponent<Rigidbody2D>();
                rb.gravityScale = 0;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                rb.mass = 10;
                circle = gameObject.AddComponent<CircleCollider2D>();
                circle.radius = transform.localScale.x;
                added = true;
            }
        }
        if(timer <= 0)
        {
            Explode();
        }
        else
            timer -= Time.deltaTime;
    }

    void Explode()
    {
        
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 3);
        foreach(Collider2D i in hits)
        {
            if(!i.isTrigger)
            {
                Vector2 direction = (i.gameObject.transform.position - transform.position);
                RaycastHit2D sight = Physics2D.Raycast(transform.position, direction, 10f, ~ignore);
                if(sight.collider != null && sight.collider.name != "Top" && sight.collider.name != "Top1")
                {
                    if(i.gameObject.tag == "Player")
                    {
                        Player_Actions p = i.gameObject.GetComponent<Player_Actions>();
                        p.TakeDamage();
                        p.AddKnockback(transform, 1000);
                    }
                    
                    else if(i.gameObject.tag == "Enemy")
                    {
                        Enemy_Actions e = i.gameObject.GetComponent<Enemy_Actions>();
                        e.TakeDamage();
                        e.AddKnockback(transform, 1000);
                    }
                }
            }
        }
        Destroy(gameObject);
    }
}
