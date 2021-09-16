using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_Trap : MonoBehaviour
{
    float coolDown = 0;
    bool startTrap = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startTrap)
        {
            if(coolDown <= 0)
            {
                print("trap gottcha");
                coolDown = 2;
            }
            else
                coolDown -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            startTrap = true;
            coolDown = 2;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            startTrap = false;
        }
    }
}
