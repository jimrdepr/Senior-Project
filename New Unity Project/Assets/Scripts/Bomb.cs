using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float timer;
    Rigidbody2D rb;
    CircleCollider2D circle;
    bool added = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer <= 2)
        {
            if(!added)
            {
                rb = gameObject.AddComponent<Rigidbody2D>();
                rb.gravityScale = 0;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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
        
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 5);
        foreach(Collider2D i in hits)
        {
            print(i.gameObject.name);
            if(i.gameObject.tag == "Player")
            {
                i.gameObject.GetComponent<Player_Actions>().TakeDamage();
            }
            if(i.gameObject.tag == "Enemy")
            {
                i.gameObject.GetComponent<Enemy_Actions>().TakeDamage();
            }
        }
        Destroy(gameObject);
    }


}
