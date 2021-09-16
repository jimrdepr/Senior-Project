using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
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
            if(i.tag == "Player")
                print("You've been hit");
            if(i.tag == "Enemy")
                i.GetComponent<Enemy_Actions>();//.gameObject.SendMessage("Die");
        }
        Destroy(gameObject);
    }


}
