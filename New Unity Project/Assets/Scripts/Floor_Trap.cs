using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Trap : MonoBehaviour
{
    bool triggered;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        sprite = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if(triggered)
            Triggered();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(!triggered && !other.isTrigger)
        {
            if(other.gameObject.tag == "Player")
            {
                triggered = true;
                Player_Actions p = other.gameObject.GetComponent<Player_Actions>();
                p.TakeDamage();
                p.AddKnockback(transform, 500);
            }

            else if(other.gameObject.tag == "Enemy")
            {
                triggered = true;
                Enemy_Actions e = other.gameObject.GetComponent<Enemy_Actions>();
                e.TakeDamage();
                e.AddKnockback(transform, 500); 
            }
                    
            else if(other.gameObject.tag == "Bomb")
            {
                triggered = true;
            }
        }
    }

    void Triggered()
    {
        sprite.color = new Color(255, 0, 0, 1);
    }
}
