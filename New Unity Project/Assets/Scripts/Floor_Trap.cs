using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Trap : MonoBehaviour
{
    float coolDown;
    bool startTrap;
    Collider2D box;
    // Start is called before the first frame update
    void Start()
    {
        coolDown = 0;
        startTrap = false;
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startTrap)
        {
            if(coolDown <= 0)
            {
                Collider2D[] hit = Physics2D.OverlapBoxAll(transform.position, box.bounds.size, 0);
                foreach(Collider2D i in hit)
                {
                    if(i.tag == "Player")
                        i.gameObject.GetComponent<Player_Actions>().TakeDamage();
                    if(i.tag == "Enemy")
                        i.gameObject.GetComponent<Enemy_Actions>().TakeDamage();
                }
                coolDown = 2;
            }
            else
                coolDown -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            startTrap = true;
            coolDown = 2;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            startTrap = false;
        }
    }
}
