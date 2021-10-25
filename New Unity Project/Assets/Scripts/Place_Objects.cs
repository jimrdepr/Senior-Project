using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place_Objects : MonoBehaviour
{
    List<Vector3> trapPos;
    List<Vector3> spiderPos;
    List<Vector3> chestPos;
    List<Vector3> bombPos;

    public GameObject trap;
    public GameObject spider;
    public GameObject chest;
    public GameObject bomb;
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
        trapPos.Add(new Vector3(-33f, 21f, 0));
        trapPos.Add(new Vector3(-35f, 21f, 0));
        trapPos.Add(new Vector3(-37f, 21f, 0));
        trapPos.Add(new Vector3(-48f, 21f, 0));
        trapPos.Add(new Vector3(-46f, 21f, 0));
        trapPos.Add(new Vector3(-44f, 21f, 0));
        trapPos.Add(new Vector3(49.5f, -18.5f, 0));
        trapPos.Add(new Vector3(50.5f, -18.5f, 0));
        trapPos.Add(new Vector3(51.5f, -18.5f, 0));
        trapPos.Add(new Vector3(51.5f, -19.5f, 0));
        trapPos.Add(new Vector3(51.5f, -20.5f, 0));
        trapPos.Add(new Vector3(51.5f, -21.5f, 0));
        trapPos.Add(new Vector3(48.5f, -19.5f, 0));
        trapPos.Add(new Vector3(48.5f, -20.5f, 0));
        trapPos.Add(new Vector3(48.5f, -21.5f, 0));
        trapPos.Add(new Vector3(48.5f, -22.5f, 0));
        trapPos.Add(new Vector3(48.5f, -23.5f, 0));
        trapPos.Add(new Vector3(48.5f, -24.5f, 0));
        trapPos.Add(new Vector3(46.5f, -19.5f, 0));
        trapPos.Add(new Vector3(46.5f, -20.5f, 0));
        trapPos.Add(new Vector3(46.5f, -21.5f, 0));
        trapPos.Add(new Vector3(46.5f, -22.5f, 0));
        trapPos.Add(new Vector3(46.5f, -23.5f, 0));
        trapPos.Add(new Vector3(46.5f, -24.5f, 0));
        trapPos.Add(new Vector3(44.5f, -19.5f, 0));
        trapPos.Add(new Vector3(44.5f, -20.5f, 0));
        trapPos.Add(new Vector3(44.5f, -21.5f, 0));
        trapPos.Add(new Vector3(44.5f, -22.5f, 0));
        trapPos.Add(new Vector3(44.5f, -23.5f, 0));
        trapPos.Add(new Vector3(44.5f, -24.5f, 0));
        trapPos.Add(new Vector3(-21f, -17f, 0));
        trapPos.Add(new Vector3(-22f, -17f, 0));
        trapPos.Add(new Vector3(-23f, -17f, 0));
        trapPos.Add(new Vector3(-24f, -17f, 0));
        trapPos.Add(new Vector3(-25f, -17f, 0));
        trapPos.Add(new Vector3(-26f, -17f, 0));
        trapPos.Add(new Vector3(-27f, -17f, 0));
        trapPos.Add(new Vector3(-34.5f, -14f, 0));

        spiderPos = new List<Vector3>();
        spiderPos.Add(new Vector3(31.75f, -7f, 0));
        spiderPos.Add(new Vector3(33.25f, -7f, 0));
        spiderPos.Add(new Vector3(-37f, -4f, 0));
        spiderPos.Add(new Vector3(-34f, -4f, 0));
        spiderPos.Add(new Vector3(-47f, 12f, 0));
        spiderPos.Add(new Vector3(-41f, 9f, 0));
        spiderPos.Add(new Vector3(-40f, 12f, 0));
        spiderPos.Add(new Vector3(-21f, 18f, 0));
        spiderPos.Add(new Vector3(-18.5f, 18f, 0));
        spiderPos.Add(new Vector3(-16f, 18f, 0));
        spiderPos.Add(new Vector3(-40.5f, 21f, 0));
        spiderPos.Add(new Vector3(2f, -17f, 0));
        spiderPos.Add(new Vector3(39.5f, -16.5f, 0));
        spiderPos.Add(new Vector3(44.5f, -16.5f, 0));
        spiderPos.Add(new Vector3(-2f, -17f, 0));
        spiderPos.Add(new Vector3(-32.5f, -11f, 0));
        spiderPos.Add(new Vector3(-44f, -13f, 0));
        spiderPos.Add(new Vector3(-47f, -11f, 0));

        chestPos = new List<Vector3>();
        chestPos.Add(new Vector3(32.5f, -8.5f, 0));
        chestPos.Add(new Vector3(-40.5f, -3.5f, 0));
        chestPos.Add(new Vector3(-49f, 12f, 0));
        chestPos.Add(new Vector3(-18.5f, 16f, 0));
        chestPos.Add(new Vector3(-49f, 21f, 0));
        chestPos.Add(new Vector3(-13.5f, -37.5f, 0));
        chestPos.Add(new Vector3(-15.5f, -35.5f, 0));
        chestPos.Add(new Vector3(-17.5f, -37.5f, 0));
        chestPos.Add(new Vector3(-47f, -16f, 0));
        chestPos.Add(new Vector3(-36.5f, -16f, 0));
        chestPos.Add(new Vector3(25.5f, -45f, 0));
        chestPos.Add(new Vector3(42f, -20f, 0));
        chestPos.Add(new Vector3(42f, -22f, 0));
        chestPos.Add(new Vector3(42f, -24f, 0));

        bombPos = new List<Vector3>();
        bombPos.Add(new Vector3(-48.5f, .5f, 0));
        bombPos.Add(new Vector3(7.5f, -13.5f, 0));

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

        foreach (Vector3 i in bombPos)
        {
            Instantiate(bomb, i, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
