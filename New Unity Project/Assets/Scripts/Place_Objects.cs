using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_Objects : MonoBehaviour
{
    List<Vector3> trapPos;
    List<Vector3> spiderPos;
    List<Vector3> chestPos;

    public GameObject trap;
    public GameObject spider;
    public GameObject chest;
    // Start is called before the first frame update
    void Start()
    {
        trapPos = new List<Vector3>();
        trapPos.Add(new Vector3(7f, -16f, 0));
        trapPos.Add(new Vector3(8f, -16f, 0));
        trapPos.Add(new Vector3(34f, -5f, 0));
        trapPos.Add(new Vector3(34f, -4f, 0));
        trapPos.Add(new Vector3(-50f, 0, 0));
        trapPos.Add(new Vector3(-50f, 1f, 0));

        spiderPos = new List<Vector3>();
        spiderPos.Add(new Vector3(31.75f, -7f, 0));
        spiderPos.Add(new Vector3(33.25f, -7f, 0));
        spiderPos.Add(new Vector3(-37f, -4f, 0));
        spiderPos.Add(new Vector3(-34f, -4f, 0));
        spiderPos.Add(new Vector3(-47f, 12f, 0));
        spiderPos.Add(new Vector3(-41f, 9f, 0));
        spiderPos.Add(new Vector3(-40f, 12f, 0));

        chestPos = new List<Vector3>();
        chestPos.Add(new Vector3(32.5f, -8.5f, 0));
        chestPos.Add(new Vector3(-40.5f, -3.5f, 0));
        chestPos.Add(new Vector3(-49f, 12f, 0));

        foreach (Vector3 i in trapPos)
        {
            Instantiate(trap, i, Quaternion.identity);  
        }
        
        foreach (Vector3 i in spiderPos)
        {
            Instantiate(spider, i, Quaternion.identity);
        }

        foreach (Vector3 i in chestPos)
        {
            Instantiate(chest, i, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
