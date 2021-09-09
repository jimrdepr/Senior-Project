using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    RaycastHit2D hit;
    float cooldown = 0;
    float range = 2;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
            direction = Vector2.up;
        if(Input.GetKey("a"))
            direction = Vector2.left;
        if(Input.GetKey("s"))
            direction = Vector2.down;
        if(Input.GetKey("d"))
            direction = Vector2.right;
        if(cooldown <= 0)
        {
            if(Input.GetKeyDown("space"))
            {
                cooldown = 1;
                Attack();
            }

        }
        else{
            cooldown -= Time.deltaTime;
        }
    }
    void Attack()
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        hit = Physics2D.Raycast(transform.position, direction, range, layerMask);
        if(hit.collider != null)
        {
            print(hit.collider.gameObject.name);
            Enemy_Actions nme = GetComponent<Enemy_Actions>();
            hit.collider.gameObject.SendMessage("TakeDamage");
        }
        else
            print("missed");
    }
}
