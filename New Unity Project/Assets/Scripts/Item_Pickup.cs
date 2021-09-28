using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        name = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<Player_Actions>().PickupItem(name);
            Destroy(gameObject);
        }
    }
}
