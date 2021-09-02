using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    float cooldown = 0;
    float range = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown <= 0)
        {
            if(Input.GetKeyDown("space"))
            {
                cooldown = 5;
                Attack();
            }

        }
        else{
            cooldown -= Time.deltaTime;
        }
    }
    void Attack()
    {
        print(cooldown);
        print("attacking");
    }
}
