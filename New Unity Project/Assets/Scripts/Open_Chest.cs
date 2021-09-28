using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Chest : MonoBehaviour
{
    public GameObject bomb;
    public GameObject heart;
    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        int itemCount = Random.Range(2, 5);
        float offsetX;
        float offsetY;
        for(int i = 0; i < itemCount; i++)
        {
            offsetX = 0;
            offsetY = 0;
            int item = Random.Range(0, 3);

            if(itemCount == 2)
            {
                if(i == 0)
                    offsetX = -0.5f;
                if(i == 1)
                    offsetX = 0.5f;
            }

            else if(itemCount == 3)
            {
                if(i == 0)
                {
                    offsetX = -0.5f;
                    offsetY = 0.5f;
                }
                if(i == 1)
                {
                    offsetX = 0.5f;
                    offsetY = 0.5f;
                }
                if(i == 2)
                {
                    offsetX = 0;
                    offsetY = -.75f;
                }
            }

            else if(itemCount == 4)
            {
                if(i == 0)
                {
                    offsetX = -0.5f;
                    offsetY = 0.5f;
                }
                if(i == 1)
                {
                    offsetX = 0.5f;
                    offsetY = 0.5f;
                }
                if(i == 2)
                {
                    offsetX = -.5f;
                    offsetY = -.5f;
                }
                if(i == 3)
                {
                    offsetX = .5f;
                    offsetY = -.5f;
                }
            }

            Vector3 position = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z);

            if(item == 0)
            {
                Instantiate(bomb, position, Quaternion.identity);  
            }
            else if(item == 1)
            {
                Instantiate(coin, position, Quaternion.identity);  
            }
            else if(item == 2)
            {
                Instantiate(heart, position, Quaternion.identity);  
            }
        }

        Destroy(gameObject);
    }
}
